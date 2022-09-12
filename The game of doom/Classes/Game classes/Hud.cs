using The_game_of_doom.Classes.Game_classes.Player_stuff;

namespace The_game_of_doom.Classes.Game_classes;

public static class Hud
{
    public static int PrintShop(Player player)
    {
        var moneyBarText = "";
        moneyBarText += "Money: ";
        moneyBarText += CreateBar(player.Money, player.MaxMoney, 10);
        moneyBarText += " " + player.Money;
        PrintText(0, 0, moneyBarText);

        var itemsInShop = "";
        itemsInShop += "Items currently in shop\n";
        itemsInShop += "-----------------------";
        
        PrintText(0, 2, itemsInShop);

        return ShopMenu(player);
    }

    private static int ShopMenu(Player player)
    {
        var rodText = "";
        
        
        //Make items display text
        //Print display text PrintText(0, 3, something);
        //select what to buy or leave
    }
    
    private static void PrintText(int x, int y, string text)
    {
        Console.SetCursorPosition(x, y);
        
        Console.Write(text);
    }
    
    private static string CreateBar(double current, double max, double lenght)
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