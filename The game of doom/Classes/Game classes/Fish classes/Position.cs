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

        public void Move(int speed)
        {
            this.PosX += this._rng.Next(-1, 2) * speed;
            this.PosY += this._rng.Next(-1, 2) * speed;
        }
    }
}