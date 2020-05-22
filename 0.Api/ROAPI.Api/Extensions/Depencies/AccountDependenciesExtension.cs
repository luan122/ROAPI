using Microsoft.Extensions.DependencyInjection;
using ROAPI.Application.Account.Interfaces.Services;
using ROAPI.Application.Account.Services;
using ROAPI.Domain.Account.Contracts.Repositories;
using ROAPI.Domain.Account.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Extensions.Dependencies
{
    public static class AccountDependenciesExtension
    {
        public static IServiceCollection AddAccountDependencies(this IServiceCollection services)
        {
            //Domain
            services.AddTransient<IAccountRepository, AccountRepository>();

            //Application
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILoginService, LoginService>();

            return services;
        }
    }
}
