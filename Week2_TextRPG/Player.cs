using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Week2_TextRPG
{
    internal class Player(string name)
    {
        private Utils utils = new Utils();

        public int level = 0;
        public string name = name;
        public string job = "전사";
        public int attack = 10;
        public int defense = 5;
        public int hp = 100;
        public int gold = 1500;
        public string weapon;
        public string armor;

        public void StatusMenu()
        {
            Console.Clear();
            DisplayStatus();

            Dictionary<string, (string label, Action action)> options = new()
            {
                // 세부 메뉴
            };

            utils.WaitForMenu(options);

            Console.Write(">> ");
            string input = Console.ReadLine();

            Console.Clear();
        }

        public void DisplayStatus()
        {
            Console.WriteLine("[ 캐릭터 상태창 ]");
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine($" 이름     : {name}");
            Console.WriteLine($" 레벨     : Lv. {level}");
            Console.WriteLine($" 직업     : {job}");
            Console.WriteLine($" 공격력   : {attack}");
            Console.WriteLine($" 방어력   : {defense}");
            Console.WriteLine($" 체력     : {hp}");
            Console.WriteLine($" 골드     : {gold} G");
            Console.WriteLine($" 무기     : {(string.IsNullOrEmpty(weapon) ? "없음" : weapon)}");
            Console.WriteLine($" 방어구   : {(string.IsNullOrEmpty(armor) ? "없음" : armor)}");
            Console.WriteLine("==================================");
            Console.WriteLine();

        }
    }
}
