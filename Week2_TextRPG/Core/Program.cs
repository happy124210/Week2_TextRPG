namespace Week2_TextRPG.Core
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            GameManager game = new GameManager();
            game.Initialize();
            game.Run();
        }
    }
}