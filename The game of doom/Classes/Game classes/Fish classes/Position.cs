namespace The_game_of_doom.Classes.Game_classes.Fish_classes
{
    [Serializable]
    public struct Position
    {
        public int PosX { get; set; } = new();
        public int PosY { get; set; } = new();

        private Random _rng = new();

        public Position() { }

        public Position(int x, int y)
        {
            this.PosX = x;
            this.PosY = y;
        }

        public Position(int lakeSize)
        {
            this.PosX = this._rng.Next(minValue: 0, maxValue: lakeSize);
            this.PosY = this._rng.Next(minValue: 0, maxValue: lakeSize);
        }

        public void Move(int speed)
        {
            this.PosX += this._rng.Next(minValue: -1, maxValue: 1) * speed;
            this.PosY += this._rng.Next(minValue: -1, maxValue: 1) * speed;
        }
    }
}