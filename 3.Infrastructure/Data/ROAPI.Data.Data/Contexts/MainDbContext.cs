using Microsoft.EntityFrameworkCore;
using ROAPI.Data.Data.Entities.Account;
using ROAPI.Data.Data.Entities.Character;

namespace ROAPI.Infrastructure.Data.Data.Contexts
{
    public class MainDbContext : BaseContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
        public DbSet<AccountEntity> Login { get; set; }
        public DbSet<CharacterEntity> Char { get; set; }
    }
}
