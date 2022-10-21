using The_game_of_doom.Classes.Game_classes.Player_stuff;

namespace The_game_of_doom.Classes.misc_classes
{
    [Serializable]
    public sealed class Radar
    {
        public Equipment.LookingAid RadarType;
        public int Uses;

        public Radar(Equipment.LookingAid la)
        {
            this.RadarType = la;

            switch (la)
            {
                case Equipment.LookingAid.None:
                    this.Uses = 0;
                    break;
                case Equipment.LookingAid.RadarT1:
                    this.Uses = 5;
                    break;
                case Equipment.LookingAid.RadarT2:
                    this.Uses = 10;
                    break;
                case Equipment.LookingAid.RadarT3:
                    this.Uses = 15;
                    break;
                case Equipment.LookingAid.RadarT4:
                    this.Uses = 20;
                    break;
                case Equipment.LookingAid.RadarT5:
                    this.Uses = 25;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(la), la, null);
            }
        }
    }
}