using The_game_of_doom.Classes.Game_classes;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom
{
    internal static class Program
    {
        private static void Main()
        {
            Console.CursorVisible = false;
            Console.WriteLine(value: "Welcome to my attempt at a fishing game!");

            //Creates the directory of saves if it does not exists
            if (!Directory.Exists(path: "saves")) Directory.CreateDirectory(path: "saves");

            //Dummy object
            Game game = null!;

            bool playedSaveBefore = false;

            //Create/load game
            switch (Asker.ForceKey(prompt: "Do you want to load a save? ", valid: "YyNn"))
            {
                case "Y" or "y":
                    if (Directory.GetFiles(path: "saves").Length == 0)
                    {
                        Console.WriteLine(value: "It seems like you dont have any saves, creating a new game.");
                        game = new Game(nothing: 0);
                        break;
                    }

                    playedSaveBefore = true;
                    game = XmlFilerDeluxe.LoadGame();

                    break;

                case "N" or "n":
                    game = new Game(nothing: 0);
                    break;
            }

            //Play game
            game.Play(playedThisSaveBefore: playedSaveBefore);
        }
    }
}