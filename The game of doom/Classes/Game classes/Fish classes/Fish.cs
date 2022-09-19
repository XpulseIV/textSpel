namespace The_game_of_doom.Classes.Game_classes.Fish_classes;

public sealed class Fish
{
    public string Name;
    
    public FishAttributes.Weight Weight;

    public FishAttributes.Speed Speed;
    
    public Position Position;

    public Fish()
    {
    }

    public Fish(int fishType, int lakeSize)
    {
        switch (fishType)
        {
            case 0:
                Name = "Herring";

                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 1:
                Name = "Salmon";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 2:
                Name = "Cod";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 3:
                Name = "Puffer fish";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 4:
                Name = "Ele";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 5:
                Name = "Clown fish";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 6:
                Name = "Angler";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 7:
                Name = "Shrimp";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 8:
                Name = "Tuna";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 9:
                Name = "Explosive barrel";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.Speed.Zero;
                
                Position = new Position(lakeSize);
                break;
            case 10:
                Name = "Goblin shark";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 11:
                Name = "Killer whale";
                
                Weight = FishAttributes.Weight.Heavy;
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 12:
                Name = "Mahi mahi";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 13:
                Name = "Ichthyococcus ovatus";
                
                Weight = FishAttributes.AssignWeight();
                Speed = FishAttributes.AssignSpeed();
                
                Position = new Position(lakeSize);
                break;
            case 14:
                Name = "Octopus";
                
                Weight = FishAttributes.Weight.Medium;
                Speed = FishAttributes.Speed.Slow;
                
                Position = new Position(lakeSize);
                break;
        }
    }
}