using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_TextRPG
{
    internal class Utils
    {
        public void WaitForMenu(Dictionary<string, (string label, Action action)> options, Action onReturn = null)
        {
            string input;

            while (true)
            {
                // 메뉴 출력
                Console.WriteLine();
                foreach (var option in options)
                {
                    Console.WriteLine($"[{option.Key}] {option.Value.label}");
                }
                Console.WriteLine("[0] 돌아가기");

                // 입력 처리
                Console.Write(">> ");
                input = Console.ReadLine();

                // 0이면 나가기
                if (input == "0")
                {
                    Console.Clear();
                    (onReturn ?? GameManager.Instance.ShowMainMenu)(); //이전 메뉴 다시 실행
                    return;
                }

                // 
                if (options.ContainsKey(input))
                {
                    Console.Clear();
                    options[input].action.Invoke(); // 연결된 함수 실행
                }

                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
    }
}
