using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Creates the directory of saves if it does not exists
            if (!Directory.Exists("saves")) Directory.CreateDirectory("saves");
            
            //Dummy object
            Game game = null!;
            
            //Create/load game
            switch (Asker.ForceKey("Do you want to load a save? ", "YyNn"))
            {
                case "Y" or "y":
                    if (Directory.GetFiles("saves").Length == 0) goto newGame;
                    
                    var fileName = Menu.SelectSaveFile();
                    game = XmlFilerDeluxe.LoadUser(fileName);
                    break;
                case "N" or "n":
                    newGame:
                    game = new Game();
                    break;
            }
            
            //Play game
            game.Play();
        }
    }
}