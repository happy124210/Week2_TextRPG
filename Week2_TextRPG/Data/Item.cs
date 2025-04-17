using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_TextRPG.Data
{
    public enum ItemType
    {
        Weapon,
        Armor
    }
    internal class Item
    {
        public string name;
        public ItemType itemType;
        public int stat;
        public string description;
        public int price;
        public bool isEquipped;
        public bool isPurchased;
    }

}
