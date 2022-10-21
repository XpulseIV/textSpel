using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes.Player_stuff
{
    [Serializable]
    public sealed class Equipment
    {
        public FishingRod Fr;
        public Line Fl;
        public Hook Fh;
        public LookingAid Lat { get; }
        public Radar La;

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
            FiveHooked
        }

        public enum LookingAid
        {
            None,
            RadarT1,
            RadarT2,
            RadarT3,
            RadarT4,
            RadarT5
        }

        public Equipment()
        {
            this.Fr = FishingRod.Normal;
            this.Fl = Line.Normal;
            this.Fh = Hook.Normal;
            this.Lat = LookingAid.None;
            this.La = new Radar(LookingAid.None);
        }
    }
}