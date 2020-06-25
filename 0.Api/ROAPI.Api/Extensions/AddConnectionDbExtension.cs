using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ROAPI.Infrastructure.Data.Data.Contexts;

namespace ROAPI.Api.Extensions
{
    public static class AddConnectionDbExtension
    {
        public static void AddConnectionDbService(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<MainDbContext>(options => {
                options.UseMySql(
                    configuration.GetConnectionString("MainConnection"));
                //options.EnableSensitiveDataLogging();
                //options.EnableDetailedErrors();
            });
            services.AddDbContext<LogDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("LogConnection")));
        }
    }
}