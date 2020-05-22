using Microsoft.Extensions.DependencyInjection;
using ROAPI.Application.Common.Contracts.Services;
using ROAPI.Application.Common.Services;
using RPAPI.Domain.Common.Contracts.Repositories;
using RPAPI.Domain.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Extensions.Depencies
{
    public static class ConfigurationsDependenciesExtension
    {
        public static IServiceCollection AddConfigurationDependencies(this IServiceCollection services)
        {
            //Domain
            services.AddTransient<IConfigurationsRepository, ConfigurationsRepository>();

            //Application
            return services.AddScoped<IConfigurationService, ConfigurationsService>();
        }
    }
}
