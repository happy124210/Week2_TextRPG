namespace Week2_TextRPG.Data
{
    public enum ItemType
    {
        Weapon,
        Armor
    }
    public class Item
    {
        public string name;
        public ItemType itemType;
        public int stat;
        public string description;
        public int price;
        public bool isEquipped;
        public bool isPurchased;

        public Item() { }
    }
}
