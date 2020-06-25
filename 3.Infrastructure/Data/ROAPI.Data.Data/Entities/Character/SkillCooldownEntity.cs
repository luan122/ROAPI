using System;
using System.Collections.Generic;
using System.Text;

namespace ROAPI.Data.Data.Entities.Character
{
    public class SkillCooldownEntity
    {
        public int account_id { get; set; }
        public int char_id { get; set; }
        public int skill { get; set; }
        public long tick { get; set; }
    }
}
