namespace The_game_of_doom
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var continuePlaying = true;
            
            while (continuePlaying)
            {
                var game = new Game();

                var error = game.Run();

                if (error != 0)
                {
                    Console.WriteLine("Something went horribly wrong! Error code is: " + error);

                    Environment.Exit(1);
                } else
                {
                    Console.WriteLine("Success!");

                    continuePlaying = Misc.ForceKey("Do you want to play again?: ", "YyNn") switch
                    {
                        "y" => true,
                        "n" => false,
                        _ => continuePlaying
                    };
                }
            }

            Console.WriteLine("Thanks for playing my game, I hope you had fun!");
        }
    }
}