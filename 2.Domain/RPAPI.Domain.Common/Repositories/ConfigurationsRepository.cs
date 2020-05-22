using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ROAPI.Data.Data.Entities.Configurations;
using RPAPI.Domain.Common.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPAPI.Domain.Common.Repositories
{
    public class ConfigurationsRepository: IConfigurationsRepository
    {
        private readonly IConfiguration _configuration;

        public ConfigurationsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public RagnarokConfiguration GetRagnarokConfigurations()
        {
            var ragnarokConfiguration = new RagnarokConfiguration();
            new ConfigureFromConfigurationOptions<RagnarokConfiguration>(
                _configuration.GetSection("RagnarokConfigurations"))
                    .Configure(ragnarokConfiguration);
            return ragnarokConfiguration;
        }
    }
}
