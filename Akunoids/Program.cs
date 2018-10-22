using System;


namespace Akunoids
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
