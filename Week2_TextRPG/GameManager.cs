using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week2_TextRPG
{
    internal class GameManager
    {
        private Dialogue dialogue = new Dialogue();
        private Character character;
        private Inventory inventory;
        private Shop shop;
        private Inn inn;
        private Dungeon dungeon;

        public void Run()
        {
            while (true)
            {
                // Intro
                Console.Clear();
                dialogue.Intro(1);
                string name = dialogue.AskPlayerName();
                character = new Character(name);
                Console.Clear();
                Console.Write(name);
                dialogue.Intro(2);

                // Main Menu
                Console.Clear();
                ShowMainMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        character.DisplayStatus();
                        break;
                    case "2":
                        inventory.ShowInventory();
                        break;
                    case "3":
                        shop.OpenShop();
                        break;
                    case "4":
                        inn.Rest();
                        break;
                    case "5":
                        dungeon.Enter();
                        break;
                    case "0":
                        Console.WriteLine("게임을 종료합니다.");
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║    TEXT RPG GAME by yuna   ║");
            Console.WriteLine("╚════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("▶ MAIN MENU");
            Console.WriteLine();
            Console.WriteLine("[1] 캐릭터 상태 보기");
            Console.WriteLine("[2] 인벤토리");
            Console.WriteLine("[3] 상점");
            Console.WriteLine("[4] 여관");
            Console.WriteLine("[5] 던전 입장");
            Console.WriteLine("[0] 게임 종료");
            Console.WriteLine();
            Console.WriteLine("────────────────────────────");
            Console.Write(">>");
        }
    }
}
