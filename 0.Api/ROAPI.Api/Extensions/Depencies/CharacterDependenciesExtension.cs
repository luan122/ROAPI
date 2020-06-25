using Microsoft.Extensions.DependencyInjection;
using ROAPI.Application.Character.Interfaces;
using ROAPI.Application.Character.Services;
using ROAPI.Domain.Character.Contracts.Repositories;
using ROAPI.Domain.Character.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Extensions.Depencies
{
    public static class CharacterDependenciesExtension
    {
        public static IServiceCollection AddCharacterDependencies(this IServiceCollection services)
        {
            //Domain
            services.AddTransient<ICharacterRepository, CharacterRepository>();

            //Application
            services.AddScoped<ICharacterService, CharacterService>();

            return services;
        }
    }
}
