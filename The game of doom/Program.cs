using System.Runtime.InteropServices;
using The_game_of_doom.Classes.Game_classes;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom
{
    internal static class Program
    {
        private const int StdOutputHandle = -11;
        private const uint EnableVirtualTerminalProcessing = 0x0004;

        [DllImport("kernel32.dll")]
        private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        private static extern uint GetLastError();

        private static void Main()
        {
            Console.Clear();

            IntPtr iStdOut = Program.GetStdHandle(Program.StdOutputHandle);
            if (!Program.GetConsoleMode(iStdOut, out uint outConsoleMode))
            {
                Console.WriteLine("failed to get output console mode");
                Console.ReadKey();
                return;
            }

            outConsoleMode |= Program.EnableVirtualTerminalProcessing;
            if (!Program.SetConsoleMode(iStdOut, outConsoleMode))
            {
                Console.WriteLine($"failed to set output console mode, error code: {Program.GetLastError()}");
                Console.ReadKey();
                return;
            }

            // Welcome and sets cursor to not visible
            Console.CursorVisible = false;
            Console.WriteLine("Welcome to my attempt at a fishing game!");

            //Creates the directory of saves if it does not exists
            if (!Directory.Exists("saves")) Directory.CreateDirectory("saves");

            //Dummy object
            Game game = null!;

            bool playedSaveBefore = false;

            //Create/load game
            switch (Asker.ForceKey("Do you want to load a save? ", "YyNn", 1))
            {
                case "Y" or "y":
                    if (Directory.GetFiles("saves").Length == 0)
                    {
                        Console.WriteLine("It seems like you dont have any saves, creating a new game.");
                        game = new Game();
                        break;
                    }

                    playedSaveBefore = true;
                    game = BinarySerialization.LoadGame();
                    break;

                case "N" or "n":
                    game = new Game();
                    break;
            }

            //Play game
            game.Play(playedSaveBefore);
        }
    }
}