using System.Data;
using Week2_TextRPG.Core;
using Week2_TextRPG.Data;

namespace Week2_TextRPG.PlayerSystem
{
    internal class Inventory(Player player)
    {
        private Utils utils = new Utils();

        private bool showIndex;
        private string title;
        private string menuMessage1;
        private string quitMessage;
        private string infoMessage;

        enum InventoryState
        { 
            Viewing, // 아이템 목록 보기
            Managing // 관리 모드
        }


        public void InventoryMenu()
        {

            InventoryState state = InventoryState.Viewing;
            
            while (true)
            {
                Console.Clear();

                // Viewing 상태
                if (state == InventoryState.Viewing)
                {
                    showIndex = false;
                    title = "[ 인벤토리 ]";
                    menuMessage1 = "[1] 장착하기";
                    quitMessage = "[0] 메인 메뉴로 돌아가기";
                    infoMessage = "";
                }
                // Managing 상태
                else if (state == InventoryState.Managing)
                {
                    showIndex = true;
                    title = "[ 장착 관리 ]";
                    menuMessage1 = "";
                    quitMessage = "[0] 취소하기";
                    infoMessage = "장착 또는 해제할 아이템을 선택하세요.";
                }

                // 메뉴 출력
                Console.WriteLine(title);
                Console.WriteLine("");
                utils.PrintItems(player.havingItems, showIndex, true, false);
                Console.WriteLine("");
                Console.WriteLine(menuMessage1);
                Console.WriteLine("");
                Console.WriteLine(quitMessage);
                Console.WriteLine("");
                Console.WriteLine(infoMessage);
                Console.Write(">> ");


                string input = Console.ReadLine();

                // 인벤토리 보기 상태 상호작용
                if (state == InventoryState.Viewing)
                {
                    switch (input)
                    {
                        case "1":
                            state = InventoryState.Managing;
                            break;

                        case "0":
                            return;

                        default:
                            break;
                    }
                }

                // 아이템 장착 관리 상태 상호작용
                else if (state == InventoryState.Managing)
                { 
                    if (input == "0")
                    {
                        state = InventoryState.Viewing;
                    }
                    else if (int.TryParse(input, out int index) && index >= 1 && index <= player.havingItems.Count)
                    {
                        Console.WriteLine();
                        ToggleEquip(player.havingItems[index - 1]);
                    }
                }
            }
        }

        public void ToggleEquip(Item selected)
        {
            if (selected.isEquipped)
            {
                selected.isEquipped = false;
                Console.WriteLine($"{selected.name}을(를) 해제했습니다.");
            }
            else
            {
                foreach (var item in player.havingItems)
                    if (item.itemType == selected.itemType && item.isEquipped)
                        item.isEquipped = false;

                selected.isEquipped = true;
                Console.WriteLine($"{selected.name}을(를) 장착했습니다.");
            }

            player.UpdateStats(GetEquippedItems());
            Console.ReadKey();
        }

        public IEnumerable<Item> GetEquippedItems()
        {
            return player.havingItems.Where(item => item.isEquipped);
        }
    }
}
