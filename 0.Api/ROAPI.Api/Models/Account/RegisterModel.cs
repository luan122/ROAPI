using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Models.Account
{
    public class RegisterModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string PinCode { get; set; } = String.Empty;
        public string Email { get; set; }
        public string Sex { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
