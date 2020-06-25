using System;
using System.Collections.Generic;
using System.Text;

namespace ROAPI.Data.Data.Entities.Character
{
    public class VendingItemsEntity
    {
        public int vending_id { get; set; }
        public int index { get; set; }
        public int cartinventory_id { get; set; }
        public int amount { get; set; }
        public int price { get; set; }
    }
}
