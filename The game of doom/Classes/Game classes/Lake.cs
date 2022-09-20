using The_game_of_doom.Classes.Game_classes.Fish_classes;

namespace The_game_of_doom.Classes.Game_classes
{
    [Serializable]
    public sealed class Lake
    {
        public string Name;

        public int Size;

        public int NumberOfFishes;

        public List<Fish> Fishes;

        public Lake() { }

        public Lake(string name, int size)
        {
            this.Name = name;

            this.Size = size;

            this.NumberOfFishes = (int)(Math.Pow(x: size, y: 2) * 0.48);

            this.Fishes = Enumerable.Range(start: 1, count: this.NumberOfFishes).Select(selector: _ => new Fish(fishType: new Random().Next(minValue: 0, maxValue: 14), lakeSize: size)).ToList();
        }
    }
}