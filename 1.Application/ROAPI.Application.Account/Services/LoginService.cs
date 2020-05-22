using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using ROAPI.Application.Account.Dtos;
using ROAPI.Domain.Account.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ROAPI.Application.Account.Interfaces.Services;
using ROAPI.Data.Data.Entities.Configurations;
using ROAPI.Application.Common.Contracts.Services;
using ROAPI.Application.Common.Utils;

namespace ROAPI.Application.Account.Services
{
    public class LoginService: ILoginService
    {
        private readonly IAccountRepository _repo;
        private readonly RagnarokConfiguration _ragnarokConfigurations;

        public LoginService(IAccountRepository repo, IConfigurationService configurationService)
        {
            _repo = repo;
            _ragnarokConfigurations = configurationService.GetRagnarokConfigurations();
        }

        public bool ValidateLogin(LoginDto dto)
        {
            if (_ragnarokConfigurations.UseMd5Pass)
                dto.user_pass = Md5Converter.Hash(dto.user_pass);
            var user = _repo.GetAll().Where(s => s.userid == dto.userid && s.user_pass == dto.user_pass).ToList();
            if(user.Count == 1)
            {
                return true;
            }
            return false;

        }
    }
}
