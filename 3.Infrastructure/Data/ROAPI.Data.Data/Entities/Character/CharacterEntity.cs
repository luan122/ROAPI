using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ROAPI.Data.Data.Entities.Character
{
    public class CharacterEntity
    {
        [Key]
        public int char_id { get; set; }
        public int account_id { get; set; }
        public bool char_num { get; set; }
        public string name { get; set; }
        public int @class { get; set; }
        public int base_level { get; set; }
        public int job_level { get; set; }
        public long base_exp { get; set; }
        public long job_exp { get; set; }
        public int zeny { get; set; }
        public int str { get; set; }
        public int agi { get; set; }
        public int vit { get; set; }
        public int @int { get; set; }
        public int dex { get; set; }
        public int luk { get; set; }
        public int max_hp { get; set; }
        public int hp { get; set; }
        public int max_sp { get; set; }
        public int sp { get; set; }
        public int status_point { get; set; }
        public int skill_point { get; set; }
        public int option { get; set; }
        public bool karma { get; set; }
        public int manner { get; set; }
        public int party_id { get; set; }
        public int guild_id { get; set; }
        public int pet_id { get; set; }
        public int homun_id { get; set; }
        public int elemental_id { get; set; }
        public bool hair { get; set; }
        public int hair_color { get; set; }
        public int clothes_color { get; set; }
        public int body { get; set; }
        public int weapon { get; set; }
        public int shield { get; set; }
        public int head_top { get; set; }
        public int head_mid { get; set; }
        public int head_bottom { get; set; }
        public int robe { get; set; }
        public string last_map { get; set; }
        public int last_x { get; set; }
        public int last_y { get; set; }
        public string save_map { get; set; }
        public int save_x { get; set; }
        public int save_y { get; set; }
        public int partner_id { get; set; }
        public bool online { get; set; }
        public int father { get; set; }
        public int mother { get; set; }
        public int child { get; set; }
        public int fame { get; set; }
        public int rename { get; set; }
        public int delete_date { get; set; }
        public int moves { get; set; }
        public int unban_time { get; set; }
        public bool font { get; set; }
        public int uniqueitem_counter { get; set; }
        public string sex { get; set; }
        public bool hotkey_rowshift { get; set; }
        public int clan_id { get; set; }
        public DateTime? last_login { get; set; }
        public int title_id { get; set; }
        public bool show_equip { get; set; }
    }
}
