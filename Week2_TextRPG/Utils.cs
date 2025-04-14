using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_TextRPG
{
    internal class Utils
    {
        public void WaitForExit()
        {
            Console.WriteLine();
            Console.WriteLine("[0] 메인 메뉴로 돌아가기");
            string input;

            do
            {
                Console.Write(">> ");
                input = Console.ReadLine();
                if (input != "0")
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            } while (input != "0");

            Console.Clear();
        }

    }
}
