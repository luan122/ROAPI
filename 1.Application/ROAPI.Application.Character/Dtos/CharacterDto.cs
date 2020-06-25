using System;
using System.Collections.Generic;
using System.Text;

namespace ROAPI.Application.Character.Dtos
{
    public class CharacterDto
    {
        public int charId { get; set; }
        public int accountId { get; set; }
        public int charNum { get; set; }
        public string name { get; set; }
        public int @class { get; set; }
        public int baseLevel { get; set; }
        public int jobLevel { get; set; }
        public long baseExp { get; set; }
        public long jobExp { get; set; }
        public int zeny { get; set; }
        public int str { get; set; }
        public int agi { get; set; }
        public int vit { get; set; }
        public int @int { get; set; }
        public int dex { get; set; }
        public int luk { get; set; }
        public int maxHp { get; set; }
        public int hp { get; set; }
        public int maxSp { get; set; }
        public int sp { get; set; }
        public int statusPoint { get; set; }
        public int skillPoint { get; set; }
        public int option { get; set; }
        public int karma { get; set; }
        public int manner { get; set; }
        public int partyId { get; set; }
        public int guildId { get; set; }
        public int petId { get; set; }
        public int homunId { get; set; }
        public int elementalId { get; set; }
        public int hair { get; set; }
        public int hairColor { get; set; }
        public int clothesColor { get; set; }
        public int body { get; set; }
        public int weapon { get; set; }
        public int shield { get; set; }
        public int headTop { get; set; }
        public int headMid { get; set; }
        public int headBottom { get; set; }
        public int robe { get; set; }
        public string lastMap { get; set; }
        public int lastX { get; set; }
        public int lastY { get; set; }
        public string saveMap { get; set; }
        public int saveX { get; set; }
        public int saveY { get; set; }
        public int partnerId { get; set; }
        public int online { get; set; }
        public int father { get; set; }
        public int mother { get; set; }
        public int child { get; set; }
        public int fame { get; set; }
        public int rename { get; set; }
        public int deleteDate { get; set; }
        public int moves { get; set; }
        public int unbanTime { get; set; }
        public int font { get; set; }
        public int uniqueitemCounter { get; set; }
        public string sex { get; set; }
        public int hotkeyRowshift { get; set; }
        public int? clanId { get; set; }
        public DateTime? lastLogin { get; set; }
        public int titleId { get; set; }
        public int showEquip { get; set; }
    }
}
