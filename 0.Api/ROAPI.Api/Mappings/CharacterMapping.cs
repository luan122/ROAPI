using AutoMapper;
using ROAPI.Api.Models.Character;
using ROAPI.Application.Character.Dtos;
using ROAPI.Data.Data.Entities.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Mappings
{
    public class CharacterMapping:Profile
    {
        public CharacterMapping()
        {
            CreateMap<CharacterModel, CharacterDto>()
                .ReverseMap();
            CreateMap<CharacterDto, CharacterEntity>()
                .ForMember(dest => dest.account_id, opt => opt.MapFrom(src => src.accountId))
                .ForMember(dest => dest.char_id, opt => opt.MapFrom(src => src.charId))
                .ForMember(dest => dest.char_num, opt => opt.MapFrom(src => src.charNum))
                .ForMember(dest => dest.base_exp, opt => opt.MapFrom(src => src.baseExp))
                .ForMember(dest => dest.base_level, opt => opt.MapFrom(src => src.baseLevel))
                .ForMember(dest => dest.clan_id, opt => opt.MapFrom(src => src.clanId))
                .ForMember(dest => dest.clothes_color, opt => opt.MapFrom(src => src.clothesColor))
                .ForMember(dest => dest.delete_date, opt => opt.MapFrom(src => src.deleteDate))
                .ForMember(dest => dest.elemental_id, opt => opt.MapFrom(src => src.elementalId))
                .ForMember(dest => dest.guild_id, opt => opt.MapFrom(src => src.guildId))
                .ForMember(dest => dest.hair_color, opt => opt.MapFrom(src => src.hairColor))
                .ForMember(dest => dest.head_bottom, opt => opt.MapFrom(src => src.headBottom))
                .ForMember(dest => dest.head_mid, opt => opt.MapFrom(src => src.headMid))
                .ForMember(dest => dest.head_top, opt => opt.MapFrom(src => src.headTop))
                .ForMember(dest => dest.homun_id, opt => opt.MapFrom(src => src.homunId))
                .ForMember(dest => dest.hotkey_rowshift, opt => opt.MapFrom(src => src.hotkeyRowshift))
                .ForMember(dest => dest.job_exp, opt => opt.MapFrom(src => src.jobExp))
                .ForMember(dest => dest.job_level, opt => opt.MapFrom(src => src.jobLevel))
                .ForMember(dest => dest.last_login, opt => opt.MapFrom(src => src.lastLogin))
                .ForMember(dest => dest.last_map, opt => opt.MapFrom(src => src.lastMap))
                .ForMember(dest => dest.last_x, opt => opt.MapFrom(src => src.lastX))
                .ForMember(dest => dest.last_y, opt => opt.MapFrom(src => src.lastY))
                .ForMember(dest => dest.max_hp, opt => opt.MapFrom(src => src.maxHp))
                .ForMember(dest => dest.max_sp, opt => opt.MapFrom(src => src.maxSp))
                .ForMember(dest => dest.partner_id, opt => opt.MapFrom(src => src.partnerId))
                .ForMember(dest => dest.party_id, opt => opt.MapFrom(src => src.partyId))
                .ForMember(dest => dest.pet_id, opt => opt.MapFrom(src => src.petId))
                .ForMember(dest => dest.save_map, opt => opt.MapFrom(src => src.saveMap))
                .ForMember(dest => dest.save_x, opt => opt.MapFrom(src => src.saveX))
                .ForMember(dest => dest.save_y, opt => opt.MapFrom(src => src.saveY))
                .ForMember(dest => dest.show_equip, opt => opt.MapFrom(src => src.showEquip))
                .ForMember(dest => dest.skill_point, opt => opt.MapFrom(src => src.skillPoint))
                .ForMember(dest => dest.status_point, opt => opt.MapFrom(src => src.statusPoint))
                .ForMember(dest => dest.title_id, opt => opt.MapFrom(src => src.titleId))
                .ForMember(dest => dest.unban_time, opt => opt.MapFrom(src => src.unbanTime))
                .ForMember(dest => dest.uniqueitem_counter, opt => opt.MapFrom(src => src.uniqueitemCounter))
                .ReverseMap();
        }
    }
}
