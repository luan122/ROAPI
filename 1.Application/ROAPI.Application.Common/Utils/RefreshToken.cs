using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ROAPI.Application.Common.Utils
{
    public static class RefreshToken
    {
        public static string Generate()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
