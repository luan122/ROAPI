using System;
using System.Collections.Generic;
using System.Text;

namespace ROAPI.Data.Data.Entities.Character
{
    public class QuestEntity
    {
        public int char_id { get; set; }
        public int quest_id { get; set; }
        public int state { get; set; }
        public int time { get; set; }
        public int count1 { get; set; }
        public int count2 { get; set; }
        public int count3 { get; set; }
    }
}
