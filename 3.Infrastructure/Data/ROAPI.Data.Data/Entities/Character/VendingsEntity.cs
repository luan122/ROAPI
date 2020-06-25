using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ROAPI.Data.Data.Entities.Character
{
    public class VendingsEntity
    {
        [Key]
        public int id { get; set; }
        public int account_id { get; set; }
        public int char_id { get; set; }
        public string sex { get; set; }
        public string map { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string title { get; set; }
        public char body_direction { get; set; }
        public char head_direction { get; set; }
        public char sit { get; set; }
        public int autotrade { get; set; }
    }
}
