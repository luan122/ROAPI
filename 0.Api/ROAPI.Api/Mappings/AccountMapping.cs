using AutoMapper;
using ROAPI.Api.Models.Account;
using ROAPI.Application.Account.Dtos;
using ROAPI.Data.Data.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Mappings
{
    public class AccountMapping : Profile
    {
        public AccountMapping()
        {
            CreateMap<AccountModel, AccountDto>()
                .ForMember(dest => dest.account_id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.userid, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.user_pass, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.sex, opt => opt.MapFrom(src => src.Sex))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.group_id, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.state, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.unban_time, opt => opt.MapFrom(src => src.UnbanTime))
                .ForMember(dest => dest.expiration_time, opt => opt.MapFrom(src => src.ExpirationTime))
                .ForMember(dest => dest.logincount, opt => opt.MapFrom(src => src.LoginCount))
                .ForMember(dest => dest.lastlogin, opt => opt.MapFrom(src => src.LastLogin))
                .ForMember(dest => dest.last_ip, opt => opt.MapFrom(src => src.LastIp))
                .ForMember(dest => dest.birthdate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.character_slots, opt => opt.MapFrom(src => src.CharacterSlots))
                .ForMember(dest => dest.pincode, opt => opt.MapFrom(src => src.Pincode))
                .ForMember(dest => dest.pincode_change, opt => opt.MapFrom(src => src.PincodeChange))
                .ForMember(dest => dest.vip_time, opt => opt.MapFrom(src => src.VipTime))
                .ForMember(dest => dest.old_group, opt => opt.MapFrom(src => src.OldGroup)).ReverseMap();

            CreateMap<AccountEntity, AccountDto>().ReverseMap();
        }
    }
}
