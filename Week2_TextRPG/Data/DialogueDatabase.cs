using System;
using System.Collections.Generic;

namespace Week2_TextRPG.UI
{
    public class DialogueLine
    {
        public string Text { get; set; }
        public ConsoleColor? Color { get; set; }

        public DialogueLine(string text, ConsoleColor? color = null)
        {
            Text = text;
            Color = color;
        }
    }

    public static class DialogueDatabase
    {
        public static List<DialogueLine> Intro1 => new()
        {
            new DialogueLine("..."),
            new DialogueLine("아, 또 다른 도전자인가."),
            new DialogueLine("...")
        };

        public static List<DialogueLine> Intro2 => new()
        {
            new DialogueLine("..."),
            new DialogueLine("어디선가 들어본 것 같군."),
            new DialogueLine("행운을 빈다."),
            new DialogueLine("의미가 있을진 모르겠지만.", ConsoleColor.DarkRed)
        };
    }
}