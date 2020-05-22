using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ROAPI.Api.Enums
{
    public enum GrantTypeEnum
    {
        [EnumMember(Value = "Password")]
        Password = 1,
        [EnumMember(Value = "RefreshToken")]
        RefreshToken
    }
}
