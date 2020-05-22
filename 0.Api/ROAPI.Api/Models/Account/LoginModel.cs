using Newtonsoft.Json.Converters;
using ROAPI.Api.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ROAPI.Api.Models.Account
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public GrantTypeEnum GrantType { get; set; }
    }
}
