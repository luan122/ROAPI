using ROAPI.Application.Common.Contracts.Services;
using ROAPI.Data.Data.Entities.Configurations;
using RPAPI.Domain.Common.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROAPI.Application.Common.Services
{
    public class ConfigurationsService : IConfigurationService
    {
        private readonly IConfigurationsRepository _configurationsRepository;

        public ConfigurationsService(IConfigurationsRepository configurationsRepository)
        {
            _configurationsRepository = configurationsRepository;
        }

        public RagnarokConfiguration GetRagnarokConfigurations()
        {
            return _configurationsRepository.GetRagnarokConfigurations();
        }
    }
}
