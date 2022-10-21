using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes.Player_stuff
{
    [Serializable]
    public sealed class Player
    {
        public string Name;

        public int Money;
        public int MaxMoney { get; }

        public Equipment Equipment;

        public List<Equipment.FishingRod> OwnedRods = new();
        public List<Equipment.Line> OwnedLines = new();
        public List<Equipment.Hook> OwnedHooks = new();
        public List<Radar> OwnedRadars = new();

        public Player(int mM)
        {
            this.Name = Asker.ForceInput("Enter your name: ");

            this.Money = 100;
            this.MaxMoney = mM;

            this.Equipment = new Equipment();

            this.OwnedRods.Add(Equipment.FishingRod.Normal);
            this.OwnedLines.Add(Equipment.Line.Normal);
            this.OwnedHooks.Add(Equipment.Hook.Normal);
            this.OwnedRadars.Add(new Radar(Equipment.LookingAid.None));
        }
    }
}