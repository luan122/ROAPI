using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROAPI.Api.Models.Character
{
    public class CharacterModel
    {
        public int CharId { get; set; }
        public int AccountId { get; set; }
        public int CharNum { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public int BaseLevel { get; set; }
        public int JobLevel { get; set; }
        public long BaseExp { get; set; }
        public long JobExp { get; set; }
        public long Zeny { get; set; }
        public int Str { get; set; }
        public int Agi { get; set; }
        public int Vit { get; set; }
        public int Int { get; set; }
        public int Dex { get; set; }
        public int Luk { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int MaxSp { get; set; }
        public int Sp { get; set; }
        public int StatusPoint { get; set; }
        public int SkillPoint { get; set; }
        public int Option { get; set; }
        public int Karma { get; set; }
        public int Manner { get; set; }
        public int PartyId { get; set; }
        public int GuildId { get; set; }
        public int PetId { get; set; }
        public int HomunId { get; set; }
        public int ElementalId { get; set; }
        public int Hair { get; set; }
        public int HairColor { get; set; }
        public int ClothesColor { get; set; }
        public int Body { get; set; }
        public int Weapon { get; set; }
        public int Shield { get; set; }
        public int HeadTop { get; set; }
        public int HeadMid { get; set; }
        public int HeadBottom { get; set; }
        public int Robe { get; set; }
        public string LastMap { get; set; }
        public int LastX { get; set; }
        public int LastY { get; set; }
        public string SaveMap { get; set; }
        public int SaveX { get; set; }
        public int SaveY { get; set; }
        public int PartnerId { get; set; }
        public int Online { get; set; }
        public int Father { get; set; }
        public int Mother { get; set; }
        public int Child { get; set; }
        public int Fame { get; set; }
        public int Rename { get; set; }
        public int DeleteDate { get; set; }
        public int Moves { get; set; }
        public int UnbanTime { get; set; }
        public int Font { get; set; }
        public int UniqueitemCounter { get; set; }
        public string Sex { get; set; }
        public int HotkeyRowshift { get; set; }
        public int? ClanId { get; set; }
        public DateTime? LastLogin { get; set; }
        public int TitleId { get; set; }
        public int ShowEquip { get; set; }
    }
}
