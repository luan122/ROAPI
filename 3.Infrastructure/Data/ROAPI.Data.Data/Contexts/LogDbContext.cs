using Microsoft.EntityFrameworkCore;

namespace ROAPI.Infrastructure.Data.Data.Contexts
{
    public class LogDbContext:BaseContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) { }
    }
}
