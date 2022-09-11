using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes.Player_classes;

[Serializable]
public class Player
{
    public string Name;

    public int Money;

    public Equipment Equipment;
    
    public Player()
    {
    }

    public Player(int nothing)
    {
        Name = Asker.ForceInput("Enter your name: ");
        Money = 0;
        Equipment = new Equipment(0);
    }
}