using Week2_TextRPG.Core;
using Week2_TextRPG.Data;

namespace Week2_TextRPG.PlayerSystem
{ 
    internal class Player(string name)
    {
        private Utils utils = new Utils();
        private static int BaseAttack = 10;
        private static int BaseDefense = 5;

        public int level = 0;
        public string name = name;
        public string job = "전사";
        public int attack = BaseAttack;
        public int defense = BaseDefense;
        public string bonusAttack = "";
        public string bonusDefense = "";
        
        public int hp = 100;
        public int exp = 0;
        public int gold = 1500;


        public string weapon;
        public string armor;

        public void StatusMenu()
        {
            Console.Clear();
            DisplayStatus();

            Console.WriteLine("[0] 메인 메뉴로 돌아가기");
            Console.Write(">> ");

            string input = Console.ReadLine();
            if (input == "0") return;
        }

        public void DisplayStatus()
        {
            Console.WriteLine("[ 캐릭터 능력치 확인 ]\n");
            Console.WriteLine("==================================");
            Console.WriteLine($" 이름     : {name}");
            Console.WriteLine($" 레벨     : Lv. {level}");
            Console.WriteLine($" 직업     : {job}");
            Console.WriteLine($" 공격력   : {attack} {bonusAttack}");
            Console.WriteLine($" 방어력   : {defense} {bonusDefense}");
            Console.WriteLine($" 체력     : {hp}");
            Console.WriteLine($" 골드     : {gold} G");
            Console.WriteLine($" 무기     : {(string.IsNullOrEmpty(weapon) ? "없음" : weapon)}");
            Console.WriteLine($" 방어구   : {(string.IsNullOrEmpty(armor) ? "없음" : armor)}");
            Console.WriteLine("==================================");
            Console.WriteLine();
        }

        public void UpdateStats(List<Item> equippedItems)
        {
            attack = BaseAttack;
            defense = BaseDefense;
            bonusAttack = "";
            bonusDefense = "";

            foreach (var item in equippedItems)
            {
                if (item.itemType == ItemType.Weapon)
                {
                    attack += item.stat;
                    bonusAttack = $"(+{item.stat})";
                }
                    
                else if (item.itemType == ItemType.Armor)
                {
                    defense += item.stat;
                    bonusDefense = $"(+{item.stat})";
                }   
            }
        }
        private void GainExp(int amount)
        {
            exp += amount;

            // 레벨업 조건
            if (exp >= level * 20)
            {
                exp -= level * 20;
                level++;
                Console.WriteLine("레벨이 올랐습니다!");
            }
        }
    }
}
