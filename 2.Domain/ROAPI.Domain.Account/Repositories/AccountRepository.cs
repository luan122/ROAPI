using System;
using System.Collections.Generic;
using System.Text;
using ROAPI.Data.Data.Entities.Account;
using ROAPI.Domain.Account.Contracts.Repositories;
using ROAPI.Infrastructure.Data.Data.Contexts;
using ROAPI.Infrastructure.Data.Data.Repositories;

namespace ROAPI.Domain.Account.Repositories
{
    public class AccountRepository : BaseRepository<AccountEntity, MainDbContext>, IAccountRepository
    {
        public AccountRepository(MainDbContext context) : base(context) { }
    }
}
