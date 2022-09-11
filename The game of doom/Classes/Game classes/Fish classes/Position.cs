namespace The_game_of_doom.Classes.Game_classes.Fish_classes;

[Serializable]
public struct Position
{
    public int PosX = new();
    public int PosY = new();

    private Random _rng = new();
    
    public Position()
    {
    }

    public Position(int x, int y)
    {
        PosX = x;
        PosY = y;
    }

    public Position(int lakeSize)
    {
        PosX = _rng.Next(0, lakeSize);
        PosY = _rng.Next(0, lakeSize);
    }

    public void Move(int speed)
    {
        PosX += _rng.Next(-1, 1) * speed;
        PosY += _rng.Next(-1, 1) * speed;
    }
}