using Week2_TextRPG.Data;

namespace Week2_TextRPG.Core
{
    public class Utils
    {
        //public void WaitForMenu(Dictionary<string, (string label, Action action)> options, Action onReturn = null)
        //{
        //    string input;

        //    while (true)
        //    {
        //        // 메뉴 출력
        //        Console.WriteLine();
        //        foreach (var option in options)
        //        {
        //            Console.WriteLine($"[{option.Key}] {option.Value.label}");
        //        }
        //        Console.WriteLine("[0] 돌아가기");

        //        // 입력 처리
        //        Console.Write(">> ");
        //        input = Console.ReadLine();

        //        // 0이면 나가기
        //        if (input == "0")
        //        {
        //            Console.Clear();
        //            (onReturn ?? GameManager.Instance.ShowMainMenu)(); //default값 메인메뉴
        //            return;
        //        }

        //        // 
        //        if (options.ContainsKey(input))
        //        {
        //            Console.Clear();
        //            options[input].action.Invoke(); // 연결된 함수 실행
        //        }

        //        else
        //        {
        //            Console.WriteLine("잘못된 입력입니다.");
        //        }
        //    }
        //}

        public void PrintItems(
                List<Item> items, 
                bool showIndex = false,
                bool showEquip = false,
                bool showPrice = false,
                bool showSellPrice = false)

        {
            int displayIndex = 1;

            foreach (var item in items)
            {
                string prefix = showIndex ? $"[{displayIndex++}] " : "";
                string priceLabel = showPrice ? $" | {item.price}원 " : "";
                string sellPriceLabel = showSellPrice ? $" | {(int)(item.price * 0.85f)}원 " : "";
                string statLabel = item.itemType == ItemType.Weapon ? "공격력" : "방어력";
                string equipped = showEquip && item.isEquipped ? " (E) " : "";

                Console.WriteLine($"{prefix}{equipped}{item.name}{priceLabel}{sellPriceLabel}| ({statLabel} +{item.stat}) | {item.description}");
            }
        }
    }
}