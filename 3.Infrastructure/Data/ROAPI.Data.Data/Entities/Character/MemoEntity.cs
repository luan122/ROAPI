using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ROAPI.Data.Data.Entities.Character
{
    public class MemoEntity
    {
        [Key]
        public int memo_id { get; set; }
        public int char_id { get; set; }
        public string map { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
}
