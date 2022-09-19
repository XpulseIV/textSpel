using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes.Player_stuff;

[Serializable]
public sealed class Player
{
    public string Name;

    public int Money;
    public int MaxMoney;

    public Equipment Equipment;

    public List<Equipment.FishingRod> ownedRods = new();
    public List<Equipment.Line> ownedLines = new();
    public List<Equipment.Hook> ownedHooks = new();
    public List<Equipment.LookingAid> ownedRadars = new();
    
    public Player()
    {
    }

    public Player(int nothing, int mM)
    {
        Name = Asker.ForceInput("Enter your name: ");
        
        Money = 100;
        MaxMoney = mM;
        
        Equipment = new Equipment(0);

        ownedRods.Add(Equipment.FishingRod.Normal);
        ownedLines.Add(Equipment.Line.Normal);
        ownedHooks.Add(Equipment.Hook.Normal);
        ownedRadars.Add(Equipment.LookingAid.None);
    }
}