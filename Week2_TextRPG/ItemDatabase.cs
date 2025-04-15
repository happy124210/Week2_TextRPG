using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_TextRPG
{
    internal static class ItemDatabase
    {
        public static List<Item> AllItems { get; } = new List<Item>
        {
            new Item
            {
                name = "낡은 검",
                itemType = ItemType.Weapon,
                stat = 5,
                price = 300,
                description = "닳아빠진 날이지만 여전히 쓸만하다."
            },
            new Item
            {
                name = "강철 검",
                itemType = ItemType.Weapon,
                stat = 12,
                price = 900,
                description = "묵직한 타격감을 자랑하는 강철 무기."
            },
            new Item
            {
                name = "천 갑옷",
                itemType = ItemType.Armor,
                stat = 3,
                price = 200,
                description = "얇지만 가볍고 활동성이 좋다."
            },
            new Item
            {
                name = "강철 갑옷",
                itemType = ItemType.Armor,
                stat = 10,
                price = 1000,
                description = "단단한 방어력을 자랑하는 무쇠 갑옷."
            }
        };
    }
}
