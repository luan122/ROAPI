using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ROAPI.Data.Data.Entities.Character
{
    public class InventoryEntity
    {
        [Key]
        public int id { get; set; }
        public int char_id { get; set; }
        public int nameid { get; set; }
        public int amount { get; set; }
        public int equip { get; set; }
        public int identify { get; set; }
        public int refine { get; set; }
        public int attribute { get; set; }
        public int card0 { get; set; }
        public int card1 { get; set; }
        public int card2 { get; set; }
        public int card3 { get; set; }
        public int option_id0 { get; set; }
        public int option_val0 { get; set; }
        public int option_parm0 { get; set; }
        public int option_id1 { get; set; }
        public int option_val1 { get; set; }
        public int option_parm1 { get; set; }
        public int option_id2 { get; set; }
        public int option_val2 { get; set; }
        public int option_parm2 { get; set; }
        public int option_id3 { get; set; }
        public int option_val3 { get; set; }
        public int option_parm3 { get; set; }
        public int option_id4 { get; set; }
        public int option_val4 { get; set; }
        public int option_parm4 { get; set; }
        public int expire_time { get; set; }
        public int favorite { get; set; }
        public int bound { get; set; }
        public long unique_id { get; set; }
        public int equip_switch { get; set; }
    }
}
