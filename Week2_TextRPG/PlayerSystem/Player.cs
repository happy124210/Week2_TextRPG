using System.Numerics;
using Week2_TextRPG.Core;
using Week2_TextRPG.Data;

namespace Week2_TextRPG.PlayerSystem
{ 
    public class Player
    {
        public Player(SaveData data)
        {
            name = data.name;
            level = data.level;
            hp = data.hp;
            exp = data.exp;
            gold = data.gold;
            isIntro = data.isIntro;

            // 인벤토리 직접 연결
            havingItems = data.havingItems ?? new List<Item>();

            // 능력치 반영
            UpdateStats(havingItems.Where(item => item.isEquipped));
        }
        public Player(string name)
        {
            this.name = name;
            level = 1;
            hp = 100;
            exp = 0;
            gold = 1500;
            isIntro = true;
            havingItems = new List<Item>();
        }

        public int level = 1;
        public string name;
        public string job = "전사";
        public int attack;
        public int defense;
        public int hp = 100;
        public int exp = 0;
        public int gold = 1500;
        public bool isIntro = true;

        public string bonusAttack = "";
        public string bonusDefense = "";

        public List<Item> havingItems = new List<Item>();

        private int baseAttack = 10;
        private int baseDefense = 5;

        public void StatusMenu()
        {
            Console.Clear();
            DisplayStatus();

            Utils.MenuOption("0", "메인 메뉴로 돌아가기\n");
            Console.Write(">> ");

            string input = Console.ReadLine();
            if (input == "0") return;
        }

        public void DisplayStatus()
        {
            string weaponName = havingItems.FirstOrDefault(i => i.isEquipped && i.itemType == ItemType.Weapon)?.name ?? "없음";
            string armorName = havingItems.FirstOrDefault(i => i.isEquipped && i.itemType == ItemType.Armor)?.name ?? "없음";

            Utils.ColoredText("[ 캐릭터 능력치 확인 ]\n\n", ConsoleColor.DarkCyan);
            Console.WriteLine("==================================\n");
            Console.WriteLine($" 이름     : {name}");
            Console.WriteLine($" 레벨     : Lv. {level}");
            Console.WriteLine($" 직업     : {job}");
            Console.Write($" 공격력   : {attack}");
            Utils.ColoredText($" {bonusAttack}\n", ConsoleColor.DarkRed);
            Console.Write($" 방어력   : {attack}");
            Utils.ColoredText($" {bonusDefense}\n", ConsoleColor.DarkRed);
            Console.Write($" 체력     : ");
            Utils.ColoredText($"{hp}\n", ConsoleColor.Green);
            Console.Write($" 골드     : ");  
            Utils.ColoredText($"{gold}", ConsoleColor.DarkYellow);
            Console.WriteLine("G");
            Console.Write(" 무기     : ");
            Utils.ColoredText($"{weaponName}\n", ConsoleColor.Gray);
            Console.Write(" 방어구   : ");
            Utils.ColoredText($"{armorName}\n", ConsoleColor.Gray);
            Console.WriteLine();
            Console.WriteLine("==================================\n");
        }

        public void UpdateStats(IEnumerable<Item> equippedItems)
        {
            attack = baseAttack;
            defense = baseDefense;
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

        public IEnumerable<Item> GetEquippedItems()
        {
            return havingItems.Where(item => item.isEquipped);
        }

        public void GainExp(int amount)
        {
            exp += amount;

            // 레벨업
            while (exp >= level * 20)
            {
                // 경험치 초기화
                exp -= level * 20;

                // 능력치 상승
                level++;
                hp = 100;
                baseAttack++;
                baseDefense++;

                // 안내 메세지 출력
                Console.WriteLine($" ! 레벨이 올랐습니다! → Lv. {level}");
                Console.WriteLine($" ! 체력이 회복되었습니다.");
                Console.WriteLine("=======================\n");
                Console.Write($" 체력     : ");
                Utils.ColoredText($"{hp}\n", ConsoleColor.Green);
                Console.Write($" 공격력   : {attack}");
                Utils.ColoredText($"(+1)\n", ConsoleColor.DarkRed);
                Console.Write($" 방어력   : {attack}");
                Utils.ColoredText($"(+1)\n", ConsoleColor.DarkRed);
                Console.WriteLine("\n=======================");
            }
        }
    }
}
