using System;

namespace snake_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Beep();
            char key;
            do{
                Game game = new Game();
                game.start();
                System.Console.WriteLine($"you lost score : {game.score}");
                System.Console.WriteLine("press any key to close the window \nor press r to restart");
                key = Console.ReadKey(true).KeyChar;
            }
            while (key == 'r');
        }
    }
}
