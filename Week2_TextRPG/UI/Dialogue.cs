using Week2_TextRPG.Core;
using Week2_TextRPG.Data;

namespace Week2_TextRPG.UI
{

    public class Dialogue
    {
        public void ShowText(List<DialogueLine> lines)
        {
            foreach (var line in lines)
            {
                if (line.Color.HasValue)
                    Utils.TypeEffect(line.Text, line.Color.Value);
                else
                    Utils.TypeEffect(line.Text);

                Console.ReadKey(true);
            }
        }


        public void Intro(int index)
        {
            switch (index)
            {
                case 1:
                    ShowText(DialogueDatabase.Intro1);
                    break;
                case 2:
                    ShowText(DialogueDatabase.Intro2);
                    break;
            }
        }


        public string AskPlayerName()
        {
            string name = "";

            while (string.IsNullOrWhiteSpace(name))
            {
                Utils.TypeEffect("이름이 뭐지?");
                Console.Write(">> ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.Clear();
                    Utils.TypeEffect("이름은 반드시 알려주어야 한다.", ConsoleColor.DarkRed);
                    Console.WriteLine();
                }
            }

            return name;
        }

        //public void EndDialogue()
        //{
        //    Console.ReadKey(true);
        //    Console.Clear();
        //}

    }
}
