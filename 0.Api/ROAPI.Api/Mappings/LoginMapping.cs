using AutoMapper;
using ROAPI.Api.Models.Account;
using ROAPI.Application.Account.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Mappings
{
    public class LoginMapping : Profile
    {
        public LoginMapping()
        {
            CreateMap<LoginModel, LoginDto>()
                .ForMember(dest => dest.userid, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.user_pass, opt => opt.MapFrom(src => src.Password)).ReverseMap();
        }
    }
}
