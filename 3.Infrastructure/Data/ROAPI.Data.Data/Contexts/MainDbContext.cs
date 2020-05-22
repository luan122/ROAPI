using Microsoft.EntityFrameworkCore;

namespace ROAPI.Infrastructure.Data.Data.Contexts
{
    public class MainDbContext : BaseContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
    }
}
