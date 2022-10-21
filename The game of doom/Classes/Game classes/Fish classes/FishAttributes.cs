using The_game_of_doom.Classes.Game_classes.Player_stuff;

namespace The_game_of_doom.Classes.Game_classes.Fish_classes
{
    [Serializable]
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

        internal static Weight AssignWeight()
        {
            int index = new Random().Next(0, 4);

            return index switch
            {
                0 => Weight.Heavy,
                1 => Weight.Medium,
                2 => Weight.Light,
                _ => Weight.Medium
            };
        }

        internal static Speed AssignSpeed()
        {
            int index = new Random().Next(0, 4);

            return index switch
            {
                0 => Speed.Fast,
                1 => Speed.Normal,
                2 => Speed.Slow,
                _ => Speed.Normal
            };
        }

        internal static List<Fish> FindAllFishesInRadius(IEnumerable<Fish> lakeFishes, Player player, int lx, int ly)
        {
            return player.Equipment.La.RadarType switch
            {
                Equipment.LookingAid.RadarT1 => (from fish in lakeFishes
                    let distanceToLookPosition =
                        Math.Sqrt(Math.Pow(lx - fish.Position.PosX, 2) + Math.Pow(ly - fish.Position.PosY, 2))
                    where Math.Abs(distanceToLookPosition - 5) <= 0.5
                    select fish).ToList(),
                Equipment.LookingAid.RadarT2 => (from fish in lakeFishes
                    let distanceToLookPosition =
                        Math.Sqrt(Math.Pow(lx - fish.Position.PosX, 2) + Math.Pow(ly - fish.Position.PosY, 2))
                    where Math.Abs(distanceToLookPosition - 10) <= 0.5
                    select fish).ToList(),
                Equipment.LookingAid.RadarT3 => (from fish in lakeFishes
                    let distanceToLookPosition =
                        Math.Sqrt(Math.Pow(lx - fish.Position.PosX, 2) + Math.Pow(ly - fish.Position.PosY, 2))
                    where Math.Abs(distanceToLookPosition - 15) <= 0.5
                    select fish).ToList(),
                Equipment.LookingAid.RadarT4 => (from fish in lakeFishes
                    let distanceToLookPosition =
                        Math.Sqrt(Math.Pow(lx - fish.Position.PosX, 2) + Math.Pow(ly - fish.Position.PosY, 2))
                    where Math.Abs(distanceToLookPosition - 20) <= 0.5
                    select fish).ToList(),
                Equipment.LookingAid.RadarT5 => (from fish in lakeFishes
                    let distanceToLookPosition =
                        Math.Sqrt(Math.Pow(lx - fish.Position.PosX, 2) + Math.Pow(ly - fish.Position.PosY, 2))
                    where Math.Abs(distanceToLookPosition - 25) <= 0.5
                    select fish).ToList(),
                _ => new List<Fish>
                {
                    Capacity = 0
                }
            };
        }
    }
}