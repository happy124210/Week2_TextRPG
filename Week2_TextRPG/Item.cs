using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2_TextRPG;

namespace Week2_TextRPG
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
