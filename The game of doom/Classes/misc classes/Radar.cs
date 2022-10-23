using The_game_of_doom.Classes.Game_classes.Player_stuff;

namespace The_game_of_doom.Classes.misc_classes
{
    [Serializable]
    public sealed class Radar
    {
        public Equipment.LookingAid RadarType;
        public int Uses;
        private double _tValue;
        private double _stepSize;

        public Radar(Equipment.LookingAid la)
        {
            this.RadarType = la;

            this.Uses = la switch
            {
                Equipment.LookingAid.None => 0,
                Equipment.LookingAid.RadarT1 => 25,
                Equipment.LookingAid.RadarT2 => 20,
                Equipment.LookingAid.RadarT3 => 15,
                Equipment.LookingAid.RadarT4 => 10,
                Equipment.LookingAid.RadarT5 => 5,
                _ => throw new ArgumentOutOfRangeException(nameof(la), la, null)
            };

            this._tValue = 0;

            this._stepSize = la switch
            {
                Equipment.LookingAid.None => 0,
                Equipment.LookingAid.RadarT1 => 1 / 25,
                Equipment.LookingAid.RadarT2 => 1 / 20,
                Equipment.LookingAid.RadarT3 => 1 / 15,
                Equipment.LookingAid.RadarT4 => 1 / 10,
                Equipment.LookingAid.RadarT5 => 1 / 5,
                _ => throw new ArgumentOutOfRangeException(nameof(la), la, null)
            };
        }

        public Radar(Equipment.LookingAid la, int uses)
        {
            this.RadarType = la;

            this.Uses = la switch
            {
                Equipment.LookingAid.None => 0,
                Equipment.LookingAid.RadarT1 => 25,
                Equipment.LookingAid.RadarT2 => 20,
                Equipment.LookingAid.RadarT3 => 15,
                Equipment.LookingAid.RadarT4 => 10,
                Equipment.LookingAid.RadarT5 => 5,
                _ => throw new ArgumentOutOfRangeException(nameof(la), la, null)
            };

            this._stepSize = la switch
            {
                Equipment.LookingAid.None => 0,
                Equipment.LookingAid.RadarT1 => 1f / 25f,
                Equipment.LookingAid.RadarT2 => 1f / 20f,
                Equipment.LookingAid.RadarT3 => 1f / 15f,
                Equipment.LookingAid.RadarT4 => 1f / 10f,
                Equipment.LookingAid.RadarT5 => 1f / 5f,
                _ => throw new ArgumentOutOfRangeException(nameof(la), la, null)
            };

            this.Uses = uses;

            this._tValue = this._stepSize * (25 - uses);
        }

        public double Lerp()
        {
            double result = (0d * (1.0f - this._tValue)) + (100d * this._tValue);
            this._tValue += this._stepSize;

            return result;
        }
    }
}