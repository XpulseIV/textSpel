namespace The_game_of_doom
{
    internal class Player
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public int Intelligence { get; set; }
        public int Speed { get; set; }
        public Clothes Clothes { get; set; }

        public Player()
        {
            Console.WriteLine("|------------------------------------------------------------------------------------------|\n" +
                              "|Welcome to the player creator!                                                            |\n" +
                              "|It is here you are given multiple options regarding name, age, and what to wear.          |\n" +
                              "|Depending on what your choices are you will be given certain advantages and disadvantages!|\n" +
                              "|------------------------------------------------------------------------------------------|\n");

            var name = Misc.ForceInput(
                "Please fill out your name, " +
                "it will not be profusely used throughout the game but may pop up once in a while!\n");

            var oldEnough = true;

            while (oldEnough)
            {
                var age = Convert.ToInt32(Misc.ForceInput(
                    "You may enter your age here as it has a quite profound impact on how the game will be played.\n"));

                switch (age)
                {
                    case < 16:
                        Console.WriteLine("Come on, you are far to young to play this game. Grow up!");
                        oldEnough = false;
                        Environment.Exit(0);
                        break;
                    case >= 16:
                        Console.WriteLine("You are old enough to proceed lol");
                        oldEnough = true;
                        break;
                }
                
                
            }
        }
    }
}