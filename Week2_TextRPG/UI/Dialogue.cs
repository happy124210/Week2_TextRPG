

namespace Week2_TextRPG.UI
{
    public class Dialogue
    {
        public void ShowText(List<string> txtList)
        {
            foreach (string str in txtList)
            {
                Console.WriteLine(str);
                Console.ReadKey(true);
            }
        }

        public void Intro(int index)
        {
            List<string> introList1 = new List<string>
            {
                "...",
                "아, 또 다른 도전자인가.",
                "..."
            };

            List<string> introList2 = new List<string>
            {
                "...",
                "어디선가 들어본 것 같군.",
                "행운을 빈다.",
                "의미가 있을진 모르겠지만."
            };

            switch (index)
            {
                case 1:
                    ShowText(introList1);
                    break;

                case 2:
                    ShowText(introList2);
                    break;
            }
        }


        public string AskPlayerName()
        {
            string name = "";

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("이름이 뭐지?");
                Console.Write(">> ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.Clear();
                    Console.WriteLine("이름은 반드시 알려주어야 한다.");
                    Console.WriteLine();
                }
            }

            return name;
        }

        public void EndDialogue()
        {
            Console.ReadKey(true);
            Console.Clear();
        }

    }
}
