using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_TextRPG
{
    internal class Inventory
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
            Console.WriteLine("[ 인벤토리 메뉴 ]");
            Console.WriteLine("");

            // 비어있을 때 문구 출력
            if (!items.Any())
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
                return;
            }

            // 아이템 출력
            foreach (var item in items)
            {
                string equippedMark = item.isEquipped ? "[E]" : "";
                string statLabel = item.itemType == ItemType.Weapon ? "공격력" : "방어력";

                Console.WriteLine($"{equippedMark} {item.name} | ({statLabel} +{item.stat}) | {item.description}");
            }
        }

        public void ManageEquip()
        {
            Console.Clear();
            Console.WriteLine("[ 장착 관리 메뉴 ]");
            Console.WriteLine("");

            Dictionary<string, (string label, Action action)> options = new()
            {
                // 세부 메뉴 없음
            };

            utils.WaitForMenu(options, InventoryMenu);

        }
    }
}
