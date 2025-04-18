namespace Week2_TextRPG.Data
{
    public static class ItemDatabase
    {
        public static List<Item> AllItems { get; } = new List<Item>
        {
            new Item
            {
                name = "도란의 검",
                itemType = ItemType.Weapon,
                stat = 3,
                price = 300,
                description = "어딘가 익숙한 작은 검이다."
            },
            new Item
            {
                name = "강철 검",
                itemType = ItemType.Weapon,
                stat = 5,
                price = 600,
                description = "묵직한 타격감을 자랑하는 강철 무기."
            },
            new Item
            {
                name = "신속의 단검",
                itemType = ItemType.Weapon,
                stat = 7,
                price = 900,
                description = "가볍고 빠르지만 치명적인 단검."
            },
            new Item
            {
                name = "용사의 검",
                itemType = ItemType.Weapon,
                stat = 15,
                price = 1500,
                description = "전설의 검. 과거 용사가 사용했다고 전해진다."
            },
            new Item
            {
                name = "도란의 방패",
                itemType = ItemType.Armor,
                stat = 3,
                price = 200,
                description = "어딘가 익숙한 작은 방패다."
            },
            new Item
            {
                name = "가죽 갑옷",
                itemType = ItemType.Armor,
                stat = 6,
                price = 500,
                description = "튼튼한 가죽으로 만든 기본 방어구."
            },
            new Item
            {
                name = "강철 갑옷",
                itemType = ItemType.Armor,
                stat = 10,
                price = 1000,
                description = "단단한 방어력을 자랑하는 무쇠 갑옷."
            },
            new Item
            {
                name = "용비늘 갑옷",
                itemType = ItemType.Armor,
                stat = 14,
                price = 1600,
                description = "용의 비늘로 만들어진 최상급 방어구."
            }
        };
    }
}
