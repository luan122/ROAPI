using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Models
{
    public class AccessTokenModel
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Message {get;set;}
    }
}
