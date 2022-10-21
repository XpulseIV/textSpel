namespace The_game_of_doom.Classes.Game_classes.Fish_classes
{
    [Serializable]
    public sealed class Fish
    {
        public string Name { get; set; }

        public FishAttributes.Weight Weight { get; set; }

        public FishAttributes.Speed Speed { get; set; }

        public Position Position { get; set; }

        internal Fish(int fishType, int lakeSize)
        {
            this.Name = "";

            switch (fishType)
            {
                case 0:
                    this.Name = "Herring";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 1:
                    this.Name = "Salmon";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 2:
                    this.Name = "Cod";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 3:
                    this.Name = "Puffer fish";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 4:
                    this.Name = "Ele";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 5:
                    this.Name = "Clown fish";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 6:
                    this.Name = "Angler";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 7:
                    this.Name = "Shrimp";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 8:
                    this.Name = "Tuna";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 9:
                    this.Name = "Explosive barrel";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.Speed.Zero;

                    this.Position = new Position(lakeSize);
                    break;
                case 10:
                    this.Name = "Goblin shark";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 11:
                    this.Name = "Killer whale";

                    this.Weight = FishAttributes.Weight.Heavy;
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 12:
                    this.Name = "Mahi mahi";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 13:
                    this.Name = "Ichthyococcus ovatus";

                    this.Weight = FishAttributes.AssignWeight();
                    this.Speed = FishAttributes.AssignSpeed();

                    this.Position = new Position(lakeSize);
                    break;
                case 14:
                    this.Name = "Octopus";

                    this.Weight = FishAttributes.Weight.Medium;
                    this.Speed = FishAttributes.Speed.Slow;

                    this.Position = new Position(lakeSize);
                    break;
            }
        }

        public Fish(string name, FishAttributes.Weight weight, FishAttributes.Speed speed, Position position)
        {
            this.Name = name;
            this.Weight = weight;
            this.Speed = speed;
            this.Position = position;
        }
    }
}