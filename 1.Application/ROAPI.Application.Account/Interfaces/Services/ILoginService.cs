using ROAPI.Application.Account.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROAPI.Application.Account.Interfaces.Services
{
    public interface ILoginService
    {
        bool ValidateLogin(LoginDto dto);
    }
}
