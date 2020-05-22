using ROAPI.Data.Data.Entities.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPAPI.Domain.Common.Contracts.Repositories
{
    public interface IConfigurationsRepository
    {
        RagnarokConfiguration GetRagnarokConfigurations();
    }
}
