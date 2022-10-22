using The_game_of_doom.Classes.Game_classes.Player_stuff;
using The_game_of_doom.Classes.Game_classes.Fish_classes;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes
{
    [Serializable]
    public sealed class Game
    {
        public Player Player;

        [NonSerialized] private Menu _menu;

        public List<Lake> Lakes;

        [NonSerialized] private Random _rng = new();

        private void Move(Game other)
        {
            this.Player = other.Player;
            this._menu = other._menu;
            this.Lakes = other.Lakes;
            this._rng = other._rng;
        }

        public void Play(bool playedThisSaveBefore)
        {
            Console.Clear();
            Console.WriteLine(playedThisSaveBefore ? "Welcome back " + this.Player.Name + "!" : "Welcome to this save, hope you have fun!");

        ChoosePlace:
            string placeToGo = Asker.ForceKey("Where do you want to go?\n" +
                                              "1: To Vänern\n" +
                                              "2: To Vättern\n" +
                                              "3: To Hjälmaren\n" +
                                              "4: To Mälaren\n" +
                                              "5: To Storsjön\n" +
                                              "6: To the shop\n" +
                                              "7: Exit game\n", "1234567", 1);
            Console.Clear();

            int lakeIndex = int.Parse(placeToGo) - 1;

            switch (lakeIndex)
            {
                case < 6:
                    this.LakeLogic(lakeIndex);

                    goto ChoosePlace;
                case 6:
                    this.ShopMenu(this.Player);

                    goto ChoosePlace;
                case 7:
                    string key = Asker.ForceKey("Do you want to save?\n" +
                                                "1: Yes\n" +
                                                "2: No\n", "YyNn");

                    switch (key)
                    {
                        case "Y" or "y":
                            BinarySerialization.SaveGame(this);
                            Environment.Exit(0);
                            break;
                        case "N" or "n":
                            Environment.Exit(0);
                            break;
                    }

                    break;
            }
        }

        public void ShopMenu(Player player)
        {
            this._menu = new Menu
            (
                "The fishers best friend",
                player.Money,
                new[]
                {
                    new Menu.Item("Rods", new[]
                    {
                        new Menu.Item("Normal rod Price: (" + Shop.FishingRodPrices[0].ItemPrice + ")", this.BuyFishingRod, 0),
                        new Menu.Item("Upgraded rod Price: (" + Shop.FishingRodPrices[1].ItemPrice + ")", this.BuyFishingRod, 1)
                    }),

                    new Menu.Item("Lines", new[]
                    {
                        new Menu.Item("Normal line Price: (" + Shop.FishingLinePrices[0].ItemPrice + ")", this.BuyFishingLine, 0),
                        new Menu.Item("Tough line Price: (" + Shop.FishingLinePrices[1].ItemPrice + ")", this.BuyFishingLine, 1)
                    }),

                    new Menu.Item("Hooks", new[]
                    {
                        new Menu.Item("One hooked Price: (" + Shop.FishingLinePrices[0].ItemPrice + ")", this.BuyFishingHook, 0),
                        new Menu.Item("Two hooked Price: (" + Shop.FishingHookPrices[1].ItemPrice + ")", this.BuyFishingHook, 1),
                        new Menu.Item("Three hooked Price: (" + Shop.FishingHookPrices[2].ItemPrice + ")", this.BuyFishingHook, 2),
                        new Menu.Item("Four hooked Price: (" + Shop.FishingHookPrices[3].ItemPrice + ")", this.BuyFishingHook, 3),
                        new Menu.Item("Five hooked Price: (" + Shop.FishingHookPrices[4].ItemPrice + ")", this.BuyFishingHook, 4)
                    }),

                    new Menu.Item("Radars", new[]
                    {
                        new Menu.Item("Radar tier 1 Price: (" + Shop.FishingLookingAidPrices[0].ItemPrice + ")", this.BuyFishingRadar, 0),
                        new Menu.Item("Radar tier 2 Price: (" + Shop.FishingLookingAidPrices[1].ItemPrice + ")", this.BuyFishingRadar, 1),
                        new Menu.Item("Radar tier 3 Price: (" + Shop.FishingLookingAidPrices[2].ItemPrice + ")", this.BuyFishingRadar, 2),
                        new Menu.Item("Radar tier 4 Price: (" + Shop.FishingLookingAidPrices[3].ItemPrice + ")", this.BuyFishingRadar, 3),
                        new Menu.Item("Radar tier 5 Price: (" + Shop.FishingLookingAidPrices[4].ItemPrice + ")", this.BuyFishingRadar, 4)
                    }),

                    new Menu.Item("Current player equipment", this.GenerateEquipmentDisplay, 0, -1),

                    new Menu.Item("Exit", this.Exit, 1, -1)
                }
            )
            {
                Main =
                {
                    MaxColumns = 1
                }
            };

            foreach (Menu.Item subMenu in this._menu.Items) subMenu.MaxColumns = 1;

            this._menu.WriteLine("Use ←↑↓→ for navigation.");
            this._menu.WriteLine("Press Esc for return to main menu.");
            this._menu.WriteLine("Press Backspace for return to parent menu.");
            this._menu.WriteLine("Press Del for clear log.");

            this._menu.Begin();
        }

        private void GenerateEquipmentDisplay()
        {
            Equipment playerEquipment = this.Player.Equipment;

            this._menu.Selected.Clear();

            this._menu.Selected.Add("Current fishing rod: " + playerEquipment.Fr, this.GenerateOwnedFishingRods);
            this._menu.Selected.Add("Current fishing line: " + playerEquipment.Fl, this.GeneratedOwnedFishingLines);
            this._menu.Selected.Add("Current fishing hook: " + playerEquipment.Fh, this.GenerateOwnedFishingHooks);
            this._menu.Selected.Add("Current fishing radar: " + playerEquipment.La.RadarType, this.GeneratedOwnedFishingRadar);
        }

        private void BuyFishingRod()
        {
            if (this.Player.OwnedRods.Contains((Equipment.FishingRod)this._menu.Selected.Index)) return;

            if (this.Player.Money < Shop.FishingRodPrices[this._menu.Selected.Index].ItemPrice) return;

            this.Player.OwnedRods.Add((Equipment.FishingRod)(this._menu.Selected.Index));
            this.Player.Money -= Shop.FishingRodPrices[this._menu.Selected.Index].ItemPrice;
        }

        private void BuyFishingLine()
        {
            if (this.Player.OwnedLines.Contains((Equipment.Line)this._menu.Selected.Index)) return;

            if (this.Player.Money < Shop.FishingLinePrices[this._menu.Selected.Index].ItemPrice) return;

            this.Player.OwnedLines.Add((Equipment.Line)this._menu.Selected.Index);
            this.Player.Money -= Shop.FishingLinePrices[this._menu.Selected.Index].ItemPrice;
        }

        private void BuyFishingHook()
        {
            if (this.Player.OwnedHooks.Contains((Equipment.Hook)this._menu.Selected.Index)) return;

            if (this.Player.Money < Shop.FishingHookPrices[this._menu.Selected.Index].ItemPrice) return;

            this.Player.OwnedHooks.Add((Equipment.Hook)this._menu.Selected.Index);
            this.Player.Money -= Shop.FishingHookPrices[this._menu.Selected.Index].ItemPrice;
        }

        private void BuyFishingRadar()
        {
            if (this.Player.Money < Shop.FishingLookingAidPrices[this._menu.Selected.Index].ItemPrice) return;

            this.Player.OwnedRadars.Add(new Radar((Equipment.LookingAid)this._menu.Selected.Index + 1));
            this.Player.Money -= Shop.FishingLookingAidPrices[this._menu.Selected.Index].ItemPrice;
        }

        private void GenerateOwnedFishingRods()
        {
            this._menu.Selected.Clear();
            for (int i = 0; i < this.Player.OwnedRods.Count; i++)
            {
                this._menu.Selected.Add("" + this.Player.OwnedRods[i], this.SelectRod, i);
            }

            this._menu.Selected.MaxColumns = 1;
        }

        private void GeneratedOwnedFishingLines()
        {
            this._menu.Selected.Clear();
            for (int i = 0; i < this.Player.OwnedLines.Count; i++)
            {
                this._menu.Selected.Add("" + this.Player.OwnedLines[i], this.SelectLine, i);
            }

            this._menu.Selected.MaxColumns = 1;
        }

        private void GenerateOwnedFishingHooks()
        {
            this._menu.Selected.Clear();
            for (int i = 0; i < this.Player.OwnedHooks.Count; i++)
            {
                this._menu.Selected.Add("" + this.Player.OwnedHooks[i], this.SelectHook, i);
            }

            this._menu.Selected.MaxColumns = 1;
        }

        private void GeneratedOwnedFishingRadar()
        {
            this._menu.Selected.Clear();
            for (int i = 0; i < this.Player.OwnedRadars.Count; i++)
            {
                this._menu.Selected.Add("[" + this.Player.OwnedRadars[i].RadarType + $", Uses left = {this.Player.OwnedRadars[i].Uses}]", this.SelectRadar, i);
            }

            this._menu.Selected.MaxColumns = 1;
        }

        private void SelectRod()
        {
            this.Player.Equipment.Fr = (Equipment.FishingRod)this._menu.Selected.Index;
        }

        private void SelectLine()
        {
            this.Player.Equipment.Fl = (Equipment.Line)this._menu.Selected.Index;
        }

        private void SelectHook()
        {
            this.Player.Equipment.Fh = (Equipment.Hook)this._menu.Selected.Index;
        }

        private void SelectRadar()
        {
            this.Player.Equipment.La = this.Player.OwnedRadars[this._menu.Selected.Index];
        }

        private void Exit()
        {
            this._menu.Close();

            Console.Clear();
        }

        public Game()
        {
            this._menu = new Menu();
            this.Player = new Player(10);

            this.Lakes = new List<Lake>
            {
                new("Vänern", 21),
                new("Vättern", 17),
                new("Hjälmaren", 13),
                new("Mälaren", 9),
                new("Storsjön", 5)
            };

            int lakeIndex = this._rng.Next(0, 5);

            this.Lakes[lakeIndex].Fishes.Add(
                new Fish("Sharknado",
                    FishAttributes.Weight.Heavy,
                    FishAttributes.Speed.Fast,
                    new Position(this.Lakes[lakeIndex].Size)
                ));

            this.Lakes[lakeIndex].NumberOfFishes++;

            foreach (Lake lake in this.Lakes)
            {
                lake.VisualLake.GenerateFishMap(lake.Fishes);
            }
        }

        public void PrintLakeTopMenu()
        {
            Console.SetCursorPosition(0, 0);
            string[] lines =
            {
                string.Concat(Enumerable.Repeat('-', 120)),
                $"| Money: {this.Player.Money}\n" +
                $"| Equipment: [Fishing rod: {this.Player.Equipment.Fr}\n" +
                $"| Fishing line: {this.Player.Equipment.Fl}\n" +
                $"| Fishing hook: {this.Player.Equipment.Fh}\n" +
                $"| Radar: {this.Player.Equipment.La.RadarType}, Uses left: {this.Player.Equipment.La.Uses}]\n",
                string.Concat(Enumerable.Repeat('-', 120))
            };

            foreach (string line in lines) Console.Write(line);
        }

        public void LakeLogic(int lakeIndex)
        {
            Game modifiedGame = this;
            this.Lakes[lakeIndex].VisualLake.Loop(ref modifiedGame);
            this.Move(modifiedGame);
        }
    }
}