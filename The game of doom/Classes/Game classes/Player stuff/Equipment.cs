namespace The_game_of_doom.Classes.Game_classes.Player_stuff;

[Serializable]
public sealed class Equipment
{
    public FishingRod Fr;
    public Line Fl;
    public Hook Fh;
    public LookingAid La;
    
    public enum FishingRod
    {
        Normal,
        Upgraded
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
        RadarT1,
        RadarT2,
        RadarT3,
        RadarT4,
        RadarT5,
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