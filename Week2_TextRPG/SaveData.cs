using Week2_TextRPG.Data;
using Week2_TextRPG.PlayerSystem;

namespace Week2_TextRPG
{
    internal class SaveData
    {
        public string name;
        public int level, hp, exp, gold;
        public bool isIntro;

        public List<Item> havingItems;

        public SaveData(Player player, List<Item> items)
        {
            name = player.name;
            level = player.level;
            hp = player.hp;
            exp = player.exp;
            gold = player.gold;
            isIntro = player.isIntro;
            this.havingItems = items;
        }

        // 역직렬화를 위한 기본 생성자
        public SaveData() { }
    }
}
