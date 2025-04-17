using Week2_TextRPG.PlayerSystem;
using Week2_TextRPG.DungeonSystem;
using Week2_TextRPG.ShopSystem;
using Week2_TextRPG.InnSysytem;
using Week2_TextRPG.Data;
using Week2_TextRPG.UI;

namespace Week2_TextRPG.Core
{
    internal class GameManager
    {
        private static GameManager instance;
        public static GameManager Instance => instance ??= new GameManager();

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
            player = new Player("고윤아");
            inventory = new Inventory(player);
            shop = new Shop(inventory, player);
            inn = new Inn(player);
            dungeon = new Dungeon(player);
        }

        public void Run()
        {
            //Intro

            if (player.isIntro)
            {
                Console.Clear();
                dialogue.Intro(1);
                string name = dialogue.AskPlayerName();
                player.name = name;
                Console.Clear();
                Console.Write(name);
                dialogue.Intro(2);
                Console.ReadKey(true);
                Console.Clear();
            }
            

            while (true)
            {
                // Main Menu
                Console.Clear();
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
                        shop.ShopMenu();
                        break;
                    case "4":
                        inn.InnMenu();
                        break;
                    case "5":
                        dungeon.DungeonMenu();
                        break;
                    case "0":
                        Console.WriteLine("게임을 종료합니다.");
                        Console.ReadKey();
                        return;
                    default:
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
            Console.WriteLine("[1] 캐릭터 능력치");
            Console.WriteLine("[2] 인벤토리");
            Console.WriteLine("[3] 상점");
            Console.WriteLine("[4] 여관");
            Console.WriteLine("[5] 던전 입장");
            Console.WriteLine();
            Console.WriteLine("[0] 게임 종료");
            Console.WriteLine();
            Console.WriteLine("────────────────────────────────");
        }
    }
}
