using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ROAPI.Data.Data.Entities.Character
{
    public class PartyEntity
    {
        [Key]
        public int party_id { get; set; }
        public string name { get; set; }
        public int exp { get; set; }
        public int item { get; set; }
        public int leader_id { get; set; }
        public int leader_char { get; set; }
    }
}
