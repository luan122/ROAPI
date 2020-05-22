using ROAPI.Data.Data.Entities.Account;
using ROAPI.Infrastructure.Data.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROAPI.Domain.Account.Contracts.Repositories
{
    public interface IAccountRepository:IBaseRepository<AccountEntity>
    {
    }
}
