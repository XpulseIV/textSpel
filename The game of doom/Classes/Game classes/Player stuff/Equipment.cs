namespace The_game_of_doom.Classes.Game_classes.Player_classes;

[Serializable]
public class Equipment
{
    public FishingRod Fr;
    public Line Fl;
    public Hook Fh;
    public LookingAid La;
    
    public enum FishingRod
    {
        Normal = 0,
        Upgraded = 1
    }
    
    public enum Line
    {
        Normal,
        Tough
    }
    
    public enum Hook
    {
        Normal,
        TwoHooked,
        ThreeHoked,
        FourHooked,
        FiveHooked,
    }
    
    public enum LookingAid
    {
        None,
        Radar
    }

    public Equipment()
    {
    }

    public Equipment(int nothing)
    {
        Fr = FishingRod.Normal;
        Fl = Line.Normal;
        Fh = Hook.Normal;
        La = LookingAid.None;
    }
}