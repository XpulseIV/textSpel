using The_game_of_doom.Classes.Game_classes.Player_stuff;

namespace The_game_of_doom.Classes.Game_classes
{
    [Serializable]
    public class Shop
    {
        public static List<Price<Equipment.FishingRod, int>> FishingRodPrices = new()
        {
            new Price<Equipment.FishingRod, int>(Equipment.FishingRod.Normal, 1),
            new Price<Equipment.FishingRod, int>(Equipment.FishingRod.Upgraded, 2)
        };

        public static List<Price<Equipment.Line, int>> FishingLinePrices = new()
        {
            new Price<Equipment.Line, int>(Equipment.Line.Normal, 1),
            new Price<Equipment.Line, int>(Equipment.Line.Tough, 2)
        };

        public static List<Price<Equipment.Hook, int>> FishingHookPrices = new()
        {
            new Price<Equipment.Hook, int>(Equipment.Hook.Normal, 1),
            new Price<Equipment.Hook, int>(Equipment.Hook.TwoHooked, 2),
            new Price<Equipment.Hook, int>(Equipment.Hook.ThreeHoked, 3),
            new Price<Equipment.Hook, int>(Equipment.Hook.FourHooked, 4),
            new Price<Equipment.Hook, int>(Equipment.Hook.FiveHooked, 5)
        };

        public static List<Price<Equipment.LookingAid, int>> FishingLookingAidPrices = new()
        {
            new Price<Equipment.LookingAid, int>(Equipment.LookingAid.RadarT1, 2),
            new Price<Equipment.LookingAid, int>(Equipment.LookingAid.RadarT2, 3),
            new Price<Equipment.LookingAid, int>(Equipment.LookingAid.RadarT3, 4),
            new Price<Equipment.LookingAid, int>(Equipment.LookingAid.RadarT4, 5),
            new Price<Equipment.LookingAid, int>(Equipment.LookingAid.RadarT5, 6)
        };
    }
}