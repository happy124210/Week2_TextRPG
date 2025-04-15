using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week2_TextRPG
{
    internal class GameManager
    {
        private Dialogue dialogue;
        private Utils utils;
        private Inventory inventory;
        private Shop shop;
        private Inn inn;
        private Dungeon dungeon;
        private Player player;

        public void Initialize()
        {
            dialogue = new Dialogue();
            utils = new Utils();
            inventory = new Inventory(this);
            shop = new Shop();
            inn = new Inn();
            dungeon = new Dungeon();
            player = new Player("고윤아");
        }

        public void Run()
        {
            // Intro

            //Console.Clear();
            //dialogue.Intro(1);
            //string name = dialogue.AskPlayerName();
            //player = new Player(name);
            //Console.Clear();
            //Console.Write(name);
            //dialogue.Intro(2);
            //Console.ReadKey(true);
            //Console.Clear();

            while (true)
            {
                // Main Menu
                
                ShowMainMenu();
                Console.Write(">> ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        player.StatusMenu();
                        break;
                    case "2":
                        inventory.InventoryMenu();
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
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }

                Console.WriteLine();
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
            Console.WriteLine("────────────────────────────────");
        }
    }
}
