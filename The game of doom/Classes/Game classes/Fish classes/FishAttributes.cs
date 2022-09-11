namespace The_game_of_doom.Classes.Game_classes.Fish_classes;

public static class FishAttributes
{
    public enum Weight
    {
        Light,
        Medium,
        Heavy
    }
    
    public enum Speed
    {
        Zero,
        Slow,
        Normal,
        Fast
    }

    public static Weight AssignWeight()
    {
        var index = new Random().Next(0, 2);

        return index switch
        {
            0 => Weight.Heavy,
            1 => Weight.Medium,
            2 => Weight.Light,
            _ => Weight.Medium
        };
    }
    
    public static Speed AssignSpeed()
    {
        var index = new Random().Next(0, 2);

        return index switch
        {
            0 => Speed.Fast,
            1 => Speed.Normal,
            2 => Speed.Slow,
            _ => Speed.Normal
        };
    }
}