using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes.Player_stuff
{
    [Serializable]
    public sealed class Player
    {
        public string Name;

        public int Money;
        public int MaxMoney;

        public Equipment Equipment;

        public List<Equipment.FishingRod> OwnedRods = new();
        public List<Equipment.Line> OwnedLines = new();
        public List<Equipment.Hook> OwnedHooks = new();
        public List<Equipment.LookingAid> OwnedRadars = new();

        public Player() { }

        public Player(int nothing, int mM)
        {
            this.Name = Asker.ForceInput(prompt: "Enter your name: ");

            this.Money = 100;
            this.MaxMoney = mM;

            this.Equipment = new Equipment(nothing: 0);

            this.OwnedRods.Add(item: Equipment.FishingRod.Normal);
            this.OwnedLines.Add(item: Equipment.Line.Normal);
            this.OwnedHooks.Add(item: Equipment.Hook.Normal);
            this.OwnedRadars.Add(item: Equipment.LookingAid.None);
        }
    }
}