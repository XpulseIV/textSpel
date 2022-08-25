using System;

namespace MyGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();

            int error = game.run();

            if (error != 0)
            {
                Console.WriteLine("Something went horribly wrong! Error code is: " + error);

                Environment.Exit(1);
            } else
            {
                Console.WriteLine("Success! Thanks for playing my game, I hope you had fun!");
            }
        }
    }
}