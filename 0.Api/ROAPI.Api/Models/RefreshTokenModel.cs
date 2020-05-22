using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Models
{
    public class RefreshTokenModel
    {
        public string Login { get; set; }
        public string RefreshToken { get; set; }
    }
}
