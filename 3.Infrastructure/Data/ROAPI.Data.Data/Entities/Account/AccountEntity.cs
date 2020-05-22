using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ROAPI.Data.Data.Entities.Account
{
    public class AccountEntity
    {
        [Key]
        public int account_id { get; set; }
        public string userid { get; set; }
        public string user_pass { get; set; }
        public string sex { get; set; }
        public string email { get; set; }
        public int group_id { get; set; }
        public int state { get; set; }
        public int unban_time { get; set; }
        public int expiration_time { get; set; }
        public int logincount { get; set; }
        public DateTime? lastlogin { get; set; }
        public string last_ip { get; set; }
        public DateTime? birthdate { get; set; }
        public int character_slots { get; set; }
        public string pincode { get; set; }
        public int pincode_change { get; set; }
        public int vip_time { get; set; }
        public int old_group { get; set; }
    }
}
