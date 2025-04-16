using System.Data;

namespace Week2_TextRPG
{
    internal class Shop(Inventory inventory, Player player)
    {
        private List<Item> shopItems;

        private Utils utils = new Utils();

        private bool showIndex;
        private bool showequipped;
        private bool showPrice;
        private bool showSellPrice;


        private string title;
        private string menuMessage1;
        private string menuMessage2;
        private string quitMessage;
        private string infoMessage;

        enum ShopState
        {
            Viewing, // 아이템 목록 보기
            Purchasing, // 구매 모드
            Selling // 판매 모드
        }


        public void ShopMenu()
        {

            ShopState state = ShopState.Viewing;

            while (true)
            {
                Console.Clear();

                // Viewing 상태
                if (state == ShopState.Viewing)
                {
                    showIndex = false;
                    showequipped = false;
                    showPrice = true;
                    showSellPrice = false;
                    title = "[ 상점 ]";
                    shopItems = ItemDatabase.AllItems.Where(i => !i.isPurchased).ToList();
                    menuMessage1 = "[1] 아이템 구매하기";
                    menuMessage2 = "[2] 아이템 판매하기";
                    quitMessage = "[0] 메인 메뉴로 돌아가기";
                    infoMessage = "";
                }
                // Purchasing 상태
                else if (state == ShopState.Purchasing)
                {
                    showIndex = true;
                    showequipped = false;
                    showPrice = true;
                    showSellPrice = false;
                    title = "[ 아이템 구매하기 ]";
                    shopItems = ItemDatabase.AllItems.Where(i => !i.isPurchased).ToList();
                    menuMessage1 = "";
                    menuMessage2 = "";
                    quitMessage = "[0] 취소하기";
                    infoMessage = "구매할 아이템을 선택하세요.";
                }
                // Selling 상태
                else if (state == ShopState.Selling)
                {
                    showIndex = true;
                    showequipped = true;
                    showPrice = false;
                    showSellPrice = true;
                    title = "[ 아이템 판매하기 ]";
                    shopItems = inventory.playerItems.ToList();
                    menuMessage1 = "";
                    menuMessage2 = "";
                    quitMessage = "[0] 취소하기";
                    infoMessage = "판매할 아이템을 선택하세요.";
                }

                Console.WriteLine(title);
                Console.WriteLine("");
                Console.WriteLine($"보유 골드: {player.gold}원");
                Console.WriteLine("");
                utils.PrintItems(shopItems, showIndex, showequipped, showPrice, showSellPrice);
                Console.WriteLine("");
                Console.WriteLine(menuMessage1);
                Console.WriteLine(menuMessage2);
                Console.WriteLine("");
                Console.WriteLine(quitMessage);
                Console.WriteLine("");
                Console.WriteLine(infoMessage);
                Console.WriteLine("");
                Console.Write(">> ");

                string input = Console.ReadLine();

                // 상점 보기 상태 상호작용
                if (state == ShopState.Viewing)
                {
                    switch (input)
                    {
                        case "1":
                            state = ShopState.Purchasing; 
                            break;

                        case "2":
                            state = ShopState.Selling;
                            break;

                        case "0":
                            return;

                        default:
                            break;
                    }

                }
                // 구매 상태 상호작용
                else if (state == ShopState.Purchasing)
                {
                    if (input == "0")
                    {
                        state = ShopState.Viewing;
                    }
                    else if (int.TryParse(input, out int index) && index >= 1 && index <= shopItems.Count)
                    {
                        PurchaseItem(shopItems[index - 1]);
                        state = ShopState.Viewing;
                    }
                }
                // 판매 상태 상호작용
                else if (state == ShopState.Selling)
                {
                    if (input == "0")
                    {
                        state = ShopState.Viewing;
                    }
                    else if (int.TryParse(input, out int index) && index >= 1 && index <= shopItems.Count)
                    {
                        SellItem(shopItems[index - 1]);
                    }
                }
            }
        }

        private void PurchaseItem(Item selected)
        {
            if (player.gold < selected.price)
            {
                Console.WriteLine("돈이 부족합니다.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{selected.name}을(를) 구매했습니다.");
                player.gold -= selected.price;
                selected.isPurchased = true;
                inventory.playerItems.Add(selected);
                inventory.ToggleEquip(selected);
            }
        }

        private void SellItem(Item selected)
        {
            if (selected.isEquipped)
            {
                Console.WriteLine($"{selected.name}을(를) 먼저 해제해야 합니다.");
                Console.WriteLine($"해제하시겠습니까?.");
                Console.WriteLine("[1] 해제하고 판매하기");
                Console.WriteLine("[0] 취소하기");
                Console.Write(">> ");
                
                string input = Console.ReadLine();
                if (input == "0") return;
                inventory.ToggleEquip(selected);
            }
            int sellPrice = (int)(selected.price * 0.85f);
            Console.WriteLine($"{selected.name}을(를) 판매했습니다. (+{sellPrice}원)");
            player.gold += sellPrice;
            selected.isPurchased = false;
            inventory.playerItems.Remove(selected);
            Console.ReadKey();
        }

    }
}
