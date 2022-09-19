using The_game_of_doom.Classes.Game_classes.Player_stuff;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes;

public static class Hud
{
    static Menu menu;
    
    private static void PrintText(int x, int y, string text)
    {
        Console.SetCursorPosition(x, y);
        
        Console.Write(text);
    }
    
    public static string CreateBar(double current, double max, double lenght)
    {
        var bar = "";
        const char barFilledChar = '\u25A0';
        const char barEmpty = ' ';
        var numberOfPointsToFill = (int)(Math.Floor((current / max) * lenght));

        bar += '[';

        for (var i = 0; i < numberOfPointsToFill; i++)
        {
            bar += barFilledChar;
        }

        for (var j = 0; j < lenght - numberOfPointsToFill; j++)
        {
            bar += barEmpty;
        }

        bar += ']';
        
        return bar;
    }
}