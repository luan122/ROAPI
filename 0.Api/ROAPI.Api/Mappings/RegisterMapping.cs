using AutoMapper;
using ROAPI.Api.Models.Account;
using ROAPI.Application.Account.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Mappings
{
    public class RegisterMapping:Profile
    {
        public RegisterMapping()
        {
            CreateMap<RegisterModel, AccountDto>()
                .ForMember(dest => dest.userid, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.user_pass, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.pincode, opt => opt.MapFrom(src => src.PinCode))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.sex, opt => opt.MapFrom(src => src.Sex))
                .ForMember(dest => dest.birthdate, opt => opt.MapFrom(src => src.BirthDate)).ReverseMap();
        }
    }
}
