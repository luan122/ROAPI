using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ROAPI.Data.Data.Entities.Character
{
    public class PetEntity
    {
        [Key]
        public int pet_id { get; set; }
        public int @class { get; set; }
        public string name { get; set; }
        public int account_id { get; set; }
        public int char_id { get; set; }
        public int level { get; set; }
        public int egg_id { get; set; }
        public int equip { get; set; }
        public int intimate { get; set; }
        public int hungry { get; set; }
        public int rename_flag { get; set; }
        public int incubate { get; set; }
        public int autofeed { get; set; }
    }
}
