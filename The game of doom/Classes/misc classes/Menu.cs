using System.Text;

namespace The_game_of_doom.Classes.misc_classes;

public static class Menu
{
    private static void PrintListing(string listing)
    {
        listing = listing[6..];
        
        Console.Clear();

        var menu = "";

        for (var i = 0; i < listing.Length + 4; i++)
        {
            menu += '#';
        }

        menu += '\n';

        menu += ("# " + listing + " #\n");
        
        for (var i = 0; i < listing.Length + 4; i++)
        {
            menu += '#';
        }
        
        menu += '\n';
        
        Console.Write(menu);
    }
    
    public static string SelectSaveFile()
    {
        var choice = new string("");
        var saveFiles = Directory.GetFiles("saves");

        var chosen = false;

        var index = 0;
        
        PrintListing(saveFiles[0]);
        
        while (!chosen)
        {
            //Console.Clear();
            var keyInfo = Console.ReadKey();
            
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    index--;

                    if (index == -1)
                    {
                        index = saveFiles.Length-1;
                        PrintListing(saveFiles[index]);
                        
                        continue;
                    }

                    PrintListing(saveFiles[index]);
                    break;
                
                case ConsoleKey.DownArrow:
                    index++;

                    if (index == saveFiles.Length+1)
                    {
                        index = 0;
                        PrintListing(saveFiles[index]);
                        
                        continue;
                    }

                    PrintListing(saveFiles[index]);
                    break;
                
                case ConsoleKey.RightArrow:
                    return saveFiles[index];
            }
        }

        return choice;
    }
}