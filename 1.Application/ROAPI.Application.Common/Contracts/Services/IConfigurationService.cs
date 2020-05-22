using ROAPI.Data.Data.Entities.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROAPI.Application.Common.Contracts.Services
{
    public interface IConfigurationService
    {
        RagnarokConfiguration GetRagnarokConfigurations();
    }
}
