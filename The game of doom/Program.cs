using The_game_of_doom.Classes.Game_classes;
using The_game_of_doom.Classes.Game_classes.Player_classes;
using The_game_of_doom.Classes.Game_classes.Player_stuff;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            var player = new Player
            {
                Name = "Test",
                Money = 1,
                MaxMoney = 10,
                Equipment = new Equipment(0)
            };

            Hud.PrintShop(player);
            
            /*
            Console.CursorVisible = false;
            Console.WriteLine("Welcome to my attempt at a fishing game!");
            
            //Creates the directory of saves if it does not exists
            if (!Directory.Exists("saves")) Directory.CreateDirectory("saves");
            
            //Dummy object
            Game game = null!;

            var playedSaveBefore = false;
            
            //Create/load game
            switch (Asker.ForceKey("Do you want to load a save? ", "YyNn"))
            {
                case "Y" or "y":
                    if (Directory.GetFiles("saves").Length == 0)
                    {
                        Console.WriteLine("It seems like you dont have any saves, creating a new game.");
                        game = new Game(0);
                        break;
                    }

                    playedSaveBefore = true;
                    game = XmlFilerDeluxe.LoadGame();
                    
                    break;
                
                case "N" or "n":
                    game = new Game(0);
                    break;
            }
            
            //Play game
            game.Play(playedSaveBefore);
            
            */
        }
    }
}