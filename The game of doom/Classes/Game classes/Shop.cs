using The_game_of_doom.Classes.Game_classes.Player_stuff;

namespace The_game_of_doom.Classes.Game_classes
{
    [Serializable]
    public class Shop
    {
        public static List<Price<Equipment.FishingRod, int>> FishingRodPrices = new()
        {
            new Price<Equipment.FishingRod, int>(item: Equipment.FishingRod.Normal, price: 1),
            new Price<Equipment.FishingRod, int>(item: Equipment.FishingRod.Upgraded, price: 2)
        };

        public static List<Price<Equipment.Line, int>> FishingLinePrices = new()
        {
            new Price<Equipment.Line, int>(item: Equipment.Line.Normal, price: 1),
            new Price<Equipment.Line, int>(item: Equipment.Line.Tough, price: 2)
        };

        public static List<Price<Equipment.Hook, int>> FishingHookPrices = new()
        {
            new Price<Equipment.Hook, int>(item: Equipment.Hook.Normal, price: 1),
            new Price<Equipment.Hook, int>(item: Equipment.Hook.TwoHooked, price: 2),
            new Price<Equipment.Hook, int>(item: Equipment.Hook.ThreeHoked, price: 3),
            new Price<Equipment.Hook, int>(item: Equipment.Hook.FourHooked, price: 4),
            new Price<Equipment.Hook, int>(item: Equipment.Hook.FiveHooked, price: 5)
        };

        public static List<Price<Equipment.LookingAid, int>> FishingLookingAidPrices = new()
        {
            new Price<Equipment.LookingAid, int>(item: Equipment.LookingAid.RadarT1, price: 2),
            new Price<Equipment.LookingAid, int>(item: Equipment.LookingAid.RadarT2, price: 3),
            new Price<Equipment.LookingAid, int>(item: Equipment.LookingAid.RadarT3, price: 4),
            new Price<Equipment.LookingAid, int>(item: Equipment.LookingAid.RadarT4, price: 5),
            new Price<Equipment.LookingAid, int>(item: Equipment.LookingAid.RadarT5, price: 6)
        };
    }
}