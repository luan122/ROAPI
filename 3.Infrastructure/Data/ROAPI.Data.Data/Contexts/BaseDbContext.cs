using Microsoft.EntityFrameworkCore;
using ROAPI.Data.Data.Entities.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROAPI.Infrastructure.Data.Data.Contexts
{
    public abstract class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options)
        : base(options)
        { }

        #region [Main Dbs]
        public DbSet<AccountEntity> Login { get; set; }
        #endregion

        #region [Log Dbs]
        #endregion
    }
}
