using The_game_of_doom.Classes.Game_classes.Player_classes;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes.Player_stuff;

[Serializable]
public class Player
{
    public string Name;

    public int Money;
    public int MaxMoney;

    public Equipment Equipment;
    
    public Player()
    {
    }

    public Player(int nothing, int mM)
    {
        Name = Asker.ForceInput("Enter your name: ");
        
        Money = 0;
        MaxMoney = mM;
        
        Equipment = new Equipment(0);
    }
}