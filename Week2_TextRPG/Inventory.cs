using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week2_TextRPG
{
    internal class Inventory(Player player)
    {
        private Utils utils = new Utils();
        
        public List<Item> items = new List<Item>();

        public void InventoryMenu()
        {
            ShowInventory();

            Dictionary<string, (string label, Action action)> options = new()
            {
                { "1", ("아이템 장착 관리", ManageEquip) }
            };

            utils.WaitForMenu(options);
        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("[ 인벤토리 ]\n");

            // 비어있을 때 문구 출력
            if (!items.Any())
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
                return;
            }

            // 아이템 출력
            foreach (var item in items)
            {
                string equippedMark = item.isEquipped ? "(E)" : "";
                string statLabel = item.itemType == ItemType.Weapon ? "공격력" : "방어력";

                Console.WriteLine($"{equippedMark} {item.name} | ({statLabel} +{item.stat}) | {item.description}");
            }
        }

        public void ManageEquip()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ 장착 관리 ]\n");

                if (!items.Any())
                {
                    Console.WriteLine("인벤토리가 비어 있습니다.");
                    return;
                }

                // 번호 붙여서 출력
                ShowItems();

                // 번호 입력 받기
                Console.WriteLine("\n[0] 취소하기");
                Console.Write("\n장착 또는 해제할 아이템 번호를 입력하세요: ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    return;
                }

                // 유효성 검사
                if (!int.TryParse(input, out int index) || index < 1 || index > items.Count)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                    continue;
                }

                // 장착 처리

                Item selected = items[index - 1];

                if (selected.isEquipped)
                {
                    selected.isEquipped = false;
                    player.UpdateStats(GetEquippedItems());
                    Console.WriteLine($"\n{selected.name}을(를) 해제했습니다.");
                    Console.Write("\n계속하려면 아무 키나 누르세요.");
                }
                else
                {
                    // 같은 타입 장비 해제
                    foreach (var item in items)
                    {
                        if (item.itemType == selected.itemType && item.isEquipped)
                            item.isEquipped = false;
                    }

                    selected.isEquipped = true;
                    player.UpdateStats(GetEquippedItems());
                    Console.WriteLine($"\n{selected.name}을(를) 장착했습니다.");
                    Console.Write("\n계속하려면 아무 키나 누르세요.");
                }
            }
        }

        private void ShowItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                string equippedMark = items[i].isEquipped ? "(E)" : "";
                string statLabel = items[i].itemType == ItemType.Weapon ? "공격력" : "방어력";

                Console.WriteLine($"[{i+1}] {equippedMark} {items[i].name} | ({statLabel} +{items[i].stat}) | {items[i].description}");
            }
        }

        public List<Item> GetEquippedItems()
        {
            return items.Where(item => item.isEquipped).ToList();
        }
    }
}
