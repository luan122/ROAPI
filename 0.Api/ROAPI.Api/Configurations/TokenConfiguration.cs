using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Configurations
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int TokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}
