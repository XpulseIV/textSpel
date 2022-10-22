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
    }
}