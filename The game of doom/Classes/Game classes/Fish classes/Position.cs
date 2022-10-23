using The_game_of_doom.Classes.Game_classes.Player_stuff;

namespace The_game_of_doom.Classes.Game_classes.Fish_classes
{
    [Serializable]
    public struct Position
    {
        public int PosX { get; set; } = new();
        public int PosY { get; set; } = new();

        [NonSerialized] private Random _rng = new();

        public Position(int x, int y)
        {
            this.PosX = x;
            this.PosY = y;
        }

        public Position(int lakeSize)
        {
            this.PosX = this._rng.Next(0, lakeSize);
            this.PosY = this._rng.Next(0, lakeSize);
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

        public Position Move(int speed, int lakeSize)
        {
            Position np = new Position(this.PosX + (this._rng.Next(-1, 2) * speed), this.PosY + (this._rng.Next(-1, 2) * speed));

            bool outsideLakeSizeX = (np.PosX <= -1) || (np.PosX >= lakeSize);
            bool outsideLakeSizeY = (np.PosY <= -1) || (np.PosY >= lakeSize);

            while (outsideLakeSizeX)
            {
                np.PosX = this._rng.Next(0, lakeSize);
                outsideLakeSizeX = (np.PosX <= -1) || (np.PosX >= lakeSize);
            }

            while (outsideLakeSizeY)
            {
                np.PosY = this._rng.Next(0, lakeSize);
                outsideLakeSizeY = (np.PosY <= -1) || (np.PosY >= lakeSize);
            }

            return np;
        }
    }
}