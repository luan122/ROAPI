using Microsoft.AspNetCore.Http;
using ROAPI.Application.Account.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ROAPI.Application.Account.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AccountDto> GetAccountInformation(int id, int groupId = 0);
        Task<AccountDto> GetAccountInformation(string login, int groupId = 0);
        Task<bool> AddAccount(AccountDto dto, IHttpContextAccessor context);
    }
}
