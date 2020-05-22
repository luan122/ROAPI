using AutoMapper;
using ROAPI.Application.Account.Dtos;
using ROAPI.Domain.Account.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ROAPI.Application.Account.Interfaces.Services;
using ROAPI.Data.Data.Entities.Account;
using Microsoft.AspNetCore.Http;
using ROAPI.Data.Data.Entities.Configurations;
using ROAPI.Application.Common.Contracts.Services;
using ROAPI.Application.Common.Utils;

namespace ROAPI.Application.Account.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly RagnarokConfiguration _ragnarokConfigurations;

        public AccountService(IAccountRepository accountRepository, IMapper mapper, IConfigurationService configurationService)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _ragnarokConfigurations = configurationService.GetRagnarokConfigurations();
        }
        public async Task<AccountDto> GetAccountInformation(int id, int groupId = 0)
        {
            var result = await _accountRepository.GetById(id);
            if (groupId < 90)
                result.user_pass = string.Empty;
            return _mapper.Map<AccountDto>(result);

        }
        public async Task<AccountDto> GetAccountInformation(string login, int groupId = 0)
        {
            var result = await _accountRepository.GetAll().Where(a => a.userid == login).FirstOrDefaultAsync();
            if (groupId < 90)
            {
                result.user_pass = string.Empty;
                result.pincode = string.Empty;
            }
            return _mapper.Map<AccountDto>(result);

        }
        public async Task<bool> AddAccount(AccountDto dto, IHttpContextAccessor context)
        {
            if (_ragnarokConfigurations.UseMd5Pass)
                dto.user_pass = Md5Converter.Hash(dto.user_pass);
            string ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    dto.last_ip = addresses[0];
                }
                else
                {
                    dto.last_ip = ipAddress;
                }
            }
            var entity = _mapper.Map<AccountEntity>(dto);
            await _accountRepository.Add(entity);
            await _accountRepository.SaveChanges();
            return entity.account_id > 0 ? true : false;
        }
    }
}
