using The_game_of_doom.Classes.Game_classes.Player_stuff;
using The_game_of_doom.Classes.Game_classes.Fish_classes;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes
{
    [Serializable]
    public sealed class Game
    {
        public Player Player;

        private Menu _menu;

        public List<Lake> Lakes;

        private Random Rng = new();

        public void Play(bool playedThisSaveBefore)
        {
            Console.WriteLine(value: playedThisSaveBefore ? "Welcome back " + this.Player.Name + "!" : "Welcome to this game, hope you have fun!");

        ChoosePlace:
            string placeToGo = Asker.ForceKey(prompt: "Where do you want to go?\n" +
                                                      "1: To Vänern\n" +
                                                      "2: To Vättern\n" +
                                                      "3: To Hjälmaren\n" +
                                                      "4: To Mälaren\n" +
                                                      "5: To Storsjön\n" +
                                                      "6: To the shop\n" +
                                                      "7: Exit game\n", valid: "1234567");

            int lakeIndex = int.Parse(s: placeToGo);

            switch (lakeIndex)
            {
                case < 6:
                    //lakeLogic();

                    goto ChoosePlace;
                case 6:
                    this.ShopMenu(player: this.Player);

                    goto ChoosePlace;
                case 7:
                    string key = Asker.ForceKey(prompt: "Do you want to save?\n" +
                                                        "1: Yes\n" +
                                                        "2: No\n", valid: "YyNn");

                    switch (key)
                    {
                        case "Y" or "y":
                            XmlFilerDeluxe.SaveGame(game: this);
                            Environment.Exit(exitCode: 0);
                            break;
                        case "N" or "n":
                            Environment.Exit(exitCode: 0);
                            break;
                    }

                    break;
            }
        }

        public void ShopMenu(Player player)
        {
            this._menu = new Menu
            (
                title: "The fishers best friend",
                m: player.Money,
                items: new[]
                {
                    new Menu.Item(name: "Rods", items: new[]
                    {
                        new Menu.Item(name: "Normal rod Price: (" + Shop.FishingRodPrices[index: 0].ItemPrice + ")", action: this.BuyFishingRod, i: 0),
                        new Menu.Item(name: "Upgraded rod Price: (" + Shop.FishingRodPrices[index: 1].ItemPrice + ")", action: this.BuyFishingRod, i: 1)
                    }),

                    new Menu.Item(name: "Lines", items: new[]
                    {
                        new Menu.Item(name: "Normal line Price: (" + Shop.FishingLinePrices[index: 0].ItemPrice + ")", action: this.BuyFishingLine, i: 0),
                        new Menu.Item(name: "Tough line Price: (" + Shop.FishingLinePrices[index: 1].ItemPrice + ")", action: this.BuyFishingLine, i: 1)
                    }),

                    new Menu.Item(name: "Hooks", items: new[]
                    {
                        new Menu.Item(name: "One hooked Price: (" + Shop.FishingLinePrices[index: 0].ItemPrice + ")", action: this.BuyFishingHook, i: 0),
                        new Menu.Item(name: "Two hooked Price: (" + Shop.FishingHookPrices[index: 1].ItemPrice + ")", action: this.BuyFishingHook, i: 1),
                        new Menu.Item(name: "Three hooked Price: (" + Shop.FishingHookPrices[index: 2].ItemPrice + ")", action: this.BuyFishingHook, i: 2),
                        new Menu.Item(name: "Four hooked Price: (" + Shop.FishingHookPrices[index: 3].ItemPrice + ")", action: this.BuyFishingHook, i: 3),
                        new Menu.Item(name: "Five hooked Price: (" + Shop.FishingHookPrices[index: 4].ItemPrice + ")", action: this.BuyFishingHook, i: 4)
                    }),

                    new Menu.Item(name: "Radars", items: new[]
                    {
                        new Menu.Item(name: "Radar tier 1 Price: (" + Shop.FishingLookingAidPrices[index: 0].ItemPrice + ")", action: this.BuyFishingRadar, i: 0),
                        new Menu.Item(name: "Radar tier 2 Price: (" + Shop.FishingLookingAidPrices[index: 1].ItemPrice + ")", action: this.BuyFishingRadar, i: 1),
                        new Menu.Item(name: "Radar tier 3 Price: (" + Shop.FishingLookingAidPrices[index: 2].ItemPrice + ")", action: this.BuyFishingRadar, i: 2),
                        new Menu.Item(name: "Radar tier 4 Price: (" + Shop.FishingLookingAidPrices[index: 3].ItemPrice + ")", action: this.BuyFishingRadar, i: 3),
                        new Menu.Item(name: "Radar tier 5 Price: (" + Shop.FishingLookingAidPrices[index: 4].ItemPrice + ")", action: this.BuyFishingRadar, i: 4)
                    }),

                    new Menu.Item(name: "Current player equipment", action: this.GenerateEquipmentDisplay, i: 0, maxColumns: -1),

                    new Menu.Item(name: "Exit", action: this.Exit, i: 0, maxColumns: -1)
                }
            )
            {
                Main =
                {
                    MaxColumns = 1
                }
            };

            foreach (Menu.Item subMenu in this._menu.Items) subMenu.MaxColumns = 1;

            this._menu.WriteLine(str: "Use ←↑↓→ for navigation.");
            this._menu.WriteLine(str: "Press Esc for return to main menu.");
            this._menu.WriteLine(str: "Press Backspace for return to parent menu.");
            this._menu.WriteLine(str: "Press Del for clear log.");

            this._menu.Begin();
        }

        private void GenerateEquipmentDisplay()
        {
            Equipment playerEquipment = this.Player.Equipment;

            this._menu.Selected.Clear();

            this._menu.Selected.Add(name: "Current fishing rod: " + playerEquipment.Fr, a: this.GenerateOwnedFishingRods);
            this._menu.Selected.Add(name: "Current fishing line: " + playerEquipment.Fl, a: this.GeneratedOwnedFishingLines);
            this._menu.Selected.Add(name: "Current fishing hook: " + playerEquipment.Fh, a: this.GenerateOwnedFishingHooks);
            this._menu.Selected.Add(name: "Current fishing radar: " + playerEquipment.La, a: this.GeneratedOwnedFishingRadar);
        }

        private void BuyFishingRod()
        {
            if (this.Player.OwnedRods.Contains(item: (Equipment.FishingRod)this._menu.Selected.Index)) return;

            if (this.Player.Money < Shop.FishingRodPrices[index: this._menu.Selected.Index].ItemPrice) return;

            this.Player.OwnedRods.Add(item: (Equipment.FishingRod)this._menu.Selected.Index);
            this.Player.Money -= Shop.FishingRodPrices[index: this._menu.Selected.Index].ItemPrice;
        }

        private void BuyFishingLine()
        {
            if (this.Player.OwnedLines.Contains(item: (Equipment.Line)this._menu.Selected.Index)) return;

            if (this.Player.Money < Shop.FishingLinePrices[index: this._menu.Selected.Index].ItemPrice) return;

            this.Player.OwnedLines.Add(item: (Equipment.Line)this._menu.Selected.Index);
            this.Player.Money -= Shop.FishingLinePrices[index: this._menu.Selected.Index].ItemPrice;
        }

        private void BuyFishingHook()
        {
            if (this.Player.OwnedHooks.Contains(item: (Equipment.Hook)this._menu.Selected.Index)) return;

            if (this.Player.Money < Shop.FishingHookPrices[index: this._menu.Selected.Index].ItemPrice) return;

            this.Player.OwnedHooks.Add(item: (Equipment.Hook)this._menu.Selected.Index);
            this.Player.Money -= Shop.FishingHookPrices[index: this._menu.Selected.Index].ItemPrice;
        }

        private void BuyFishingRadar()
        {
            if (this.Player.OwnedRadars.Contains(item: (Equipment.LookingAid)this._menu.Selected.Index)) return;

            if (this.Player.Money < Shop.FishingLookingAidPrices[index: this._menu.Selected.Index].ItemPrice) return;

            this.Player.OwnedRadars.Add(item: (Equipment.LookingAid)this._menu.Selected.Index);
            this.Player.Money -= Shop.FishingLookingAidPrices[index: this._menu.Selected.Index].ItemPrice;
        }

        private void GenerateOwnedFishingRods()
        {
            this._menu.Selected.Clear();
            foreach (Equipment.FishingRod t in this.Player.OwnedRods) this._menu.Selected.Add(name: "" + t, a: this.SelectRod);
        }

        private void GeneratedOwnedFishingLines()
        {
            this._menu.Selected.Clear();
            foreach (Equipment.Line t in this.Player.OwnedLines) this._menu.Selected.Add(name: "" + t, a: null);
        }

        private void GenerateOwnedFishingHooks()
        {
            this._menu.Selected.Clear();
            foreach (Equipment.Hook t in this.Player.OwnedHooks) this._menu.Selected.Add(name: "" + t, a: null);
        }

        private void GeneratedOwnedFishingRadar()
        {
            this._menu.Selected.Clear();
            foreach (Equipment.LookingAid t in this.Player.OwnedRadars) this._menu.Selected.Add(name: "" + t, a: null);
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
            this.Player.Equipment.La = (Equipment.LookingAid)this._menu.Selected.Index;
        }

        private void Exit()
        {
            this._menu.Close();

            Console.Clear();
        }


        public Game() { }

        public Game(int nothing)
        {
            this.Player = new Player(nothing: 0, mM: 10);

            this.Lakes = new List<Lake>
            {
                new(name: "Vänern", size: 40),
                new(name: "Vättern", size: 35),
                new(name: "Hjälmaren", size: 30),
                new(name: "Mälaren", size: 25),
                new(name: "Storsjön", size: 20)
            };

            int lakeIndex = this.Rng.Next(minValue: 0, maxValue: 4);

            this.Lakes[index: lakeIndex].Fishes.Add(item: new Fish
            {
                Name = "Sharknado",

                Weight = FishAttributes.Weight.Heavy,
                Speed = FishAttributes.Speed.Fast,

                Position = new Position(lakeSize: this.Lakes[index: lakeIndex].Size)
            });

            this.Lakes[index: lakeIndex].NumberOfFishes++;
        }
    }
}