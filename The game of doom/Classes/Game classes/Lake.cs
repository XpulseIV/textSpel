using The_game_of_doom.Classes.Game_classes.Fish_classes;

namespace The_game_of_doom.Classes.Game_classes;

[Serializable]
public sealed class Lake
{
    public string Name;

    public int Size;

    public int NumberOfFishes;
    
    public List<Fish> Fishes;

    public Lake()
    {
    }

    public Lake(string name, int size)
    {
        Name = name;
        
        Size = size;

        NumberOfFishes = (int)(Math.Pow(size, 2) * 0.48);

        Fishes = Enumerable.Range(1, NumberOfFishes).Select(_ => new Fish(new Random().Next(0, 14), size)).ToList();
    }
}