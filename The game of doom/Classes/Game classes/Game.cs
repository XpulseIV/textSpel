using The_game_of_doom.Classes.Game_classes.Player_stuff;
using The_game_of_doom.Classes.Game_classes.Fish_classes;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes;

[Serializable]
public sealed class Game
{
    public Player Player;

    private Menu _menu;

    public List<Lake> Lakes;

    public Random Rng = new();
    
    public void Play(bool playedThisSaveBefore)
    {
        Console.WriteLine(playedThisSaveBefore ? "Welcome back " + Player.Name + "!": "Welcome to this game, hope you have fun!");

        ChoosePlace:
        var placeToGo = Asker.ForceKey("Where do you want to go?\n" +
                                       "1: To Vänern\n" +
                                       "2: To Vättern\n" +
                                       "3: To Hjälmaren\n" +
                                       "4: To Mälaren\n" +
                                       "5: To Storsjön\n" +
                                       "6: To the shop\n" +
                                       "7: Exit game\n", "1234567");

        var lakeIndex = int.Parse(placeToGo);
        
        switch (lakeIndex)
        {
            case < 6:
                //lakeLogic();
            
                goto ChoosePlace;
            case 6:
                ShopMenu(Player);
            
                goto ChoosePlace;
            case 7:
                var key = Asker.ForceKey("Do you want to save?\n" +
                    "1: Yes\n" +
                    "2: No\n", "YyNn");

                switch (key)
                {
                    case "Y" or "y":
                        XmlFilerDeluxe.SaveGame(this);
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
        _menu = new Menu
        (
            "The fishers best friend",

            new[]
            {
                    new Menu.Item("Rods", new[]
                    {
                        new Menu.Item("Normal rod Price: (" + Shop.FishingRodPrices[0].ItemPrice + ")", BuyFishingRod, 0),
                        new Menu.Item("Upgraded rod Price: (" + Shop.FishingRodPrices[1].ItemPrice + ")", BuyFishingRod, 1)
                    }),

                    new Menu.Item("Lines", new[]
                    {
                        new Menu.Item("Normal line Price: (" + Shop.FishingLinePrices[0].ItemPrice + ")", BuyFishingLine, 0),
                        new Menu.Item("Tough line Price: (" + Shop.FishingLinePrices[1].ItemPrice + ")", BuyFishingLine, 1)
                    }),

                    new Menu.Item("Hooks", new[]
                    {
                        new Menu.Item("One hooked Price: ("+ Shop.FishingLinePrices[0].ItemPrice + ")", BuyFishingHook, 0),
                        new Menu.Item("Two hooked Price: (" + Shop.FishingHookPrices[1].ItemPrice + ")", BuyFishingHook, 1),
                        new Menu.Item("Three hooked Price: (" + Shop.FishingHookPrices[2].ItemPrice + ")", BuyFishingHook, 2),
                        new Menu.Item("Four hooked Price: (" + Shop.FishingHookPrices[3].ItemPrice + ")", BuyFishingHook, 3),
                        new Menu.Item("Five hooked Price: (" + Shop.FishingHookPrices[4].ItemPrice + ")", BuyFishingHook, 4)
                    }),

                    new Menu.Item("Radars", new[]
                    {
                        new Menu.Item("Radar tier 1 Price: (" + Shop.FishingLookingAidPrices[0].ItemPrice + ")", BuyFishingRadar, 0),
                        new Menu.Item("Radar tier 2 Price: (" + + Shop.FishingLookingAidPrices[0].ItemPrice + ")", BuyFishingRadar, 0, 1),
                        new Menu.Item("Radar tier 3 Price: (" + + Shop.FishingLookingAidPrices[0].ItemPrice + ")", BuyFishingRadar, 0, 2),
                        new Menu.Item("Radar tier 4 Price: (" + + Shop.FishingLookingAidPrices[0].ItemPrice + ")", BuyFishingRadar, 0, 3),
                        new Menu.Item("Radar tier 5 Price: (" + + Shop.FishingLookingAidPrices[0].ItemPrice + ")", BuyFishingRadar, 0, 4)
                    }),

                    new Menu.Item("Current player equipment", GenerateEquipmentDisplay, 0, -1),

                new Menu.Item("Exit", Exit, 0, -1),
            }
        );

        _menu.Main.MaxColumns = 1;

        foreach (var subMenu in _menu.Items)
        {
            subMenu.MaxColumns = 1;
        }

        _menu.WriteLine("Use ←↑↓→ for navigation.");
        _menu.WriteLine("Press Esc for return to main menu.");
        _menu.WriteLine("Press Backspace for return to parent menu.");
        _menu.WriteLine("Press Del for clear log.");

        _menu.Begin();
    }

    private void GenerateEquipmentDisplay()
    {
        var playerEquipment = Player.Equipment;

        _menu.Selected.Clear();

        _menu.Selected.Add("Current fishing rod: " + playerEquipment.Fr, GenerateOwnedFishingRods);
        _menu.Selected.Add("Current fishing line: " + playerEquipment.Fl, GeneratedOwnedFishingLines);
        _menu.Selected.Add("Current fishing hook: " + playerEquipment.Fh, GenerateOwnedFishingHooks);
        _menu.Selected.Add("Current fishing radar: " + playerEquipment.La, GeneratedOwnedFishingRadar);
    }

    private void BuyFishingRod()
    {
        if (Player.ownedRods.Contains((Equipment.FishingRod)_menu.Selected.Index)) return;

        if (Player.Money < Shop.FishingRodPrices[_menu.Selected.Index].ItemPrice) return;
        
        Player.ownedRods.Add((Equipment.FishingRod)_menu.Selected.Index);
        Player.Money -= Shop.FishingRodPrices[_menu.Selected.Index].ItemPrice;
    }

    private void BuyFishingLine()
    {
        if (Player.ownedLines.Contains((Equipment.Line)_menu.Selected.Index)) return;

        if (Player.Money < Shop.FishingLinePrices[_menu.Selected.Index].ItemPrice) return;
        
        Player.ownedLines.Add((Equipment.Line)_menu.Selected.Index);
        Player.Money -= Shop.FishingLinePrices[_menu.Selected.Index].ItemPrice;
    }

    private void BuyFishingHook()
    {
        if (Player.ownedHooks.Contains((Equipment.Hook)_menu.Selected.Index)) return;

        if (Player.Money < Shop.FishingHookPrices[_menu.Selected.Index].ItemPrice) return;
        
        Player.ownedHooks.Add((Equipment.Hook)_menu.Selected.Index);
        Player.Money -= Shop.FishingHookPrices[_menu.Selected.Index].ItemPrice;
    }

    private void BuyFishingRadar()
    {
        if (Player.ownedRadars.Contains((Equipment.LookingAid)_menu.Selected.Index)) return;

        if (Player.Money < Shop.FishingLookingAidPrices[_menu.Selected.Index].ItemPrice) return;
        
        Player.ownedRadars.Add((Equipment.LookingAid)_menu.Selected.Index);
        Player.Money -= Shop.FishingLookingAidPrices[_menu.Selected.Index].ItemPrice;
    }

    private void GenerateOwnedFishingRods()
    {
        _menu.Selected.Clear();
        foreach (var t in Player.ownedRods)
        {
            _menu.Selected.Add("" + t, SelectRod);
        }
    }

    private void GeneratedOwnedFishingLines()
    {
        _menu.Selected.Clear();
        foreach (var t in Player.ownedLines)
        {
            _menu.Selected.Add("" + t, null);
        }
    }

    private void GenerateOwnedFishingHooks()
    {
        _menu.Selected.Clear();
        foreach (var t in Player.ownedHooks)
        {
            _menu.Selected.Add("" + t, null);
        }
    }

    private void GeneratedOwnedFishingRadar()
    {
        _menu.Selected.Clear();
        foreach (var t in Player.ownedRadars)
        {
            _menu.Selected.Add("" + t, null);
        }
    }

    private void SelectRod()
    {
        Player.Equipment.Fr = (Equipment.FishingRod)(_menu.Selected.Index);
    }
    
    private void SelectLine()
    {
        Player.Equipment.Fl = (Equipment.Line)(_menu.Selected.Index);
    }
    
    private void SelectHook()
    {
        Player.Equipment.Fh = (Equipment.Hook)(_menu.Selected.Index);
    }
    
    private void SelectRadar()
    {
        Player.Equipment.La = (Equipment.LookingAid)(_menu.Selected.Index);
    }
    
    private void Exit()
    {
        _menu.Close();

        Console.Clear();
    }





























    public Game()
    {
    }

    public Game(int nothing)
    {
        Player = new Player(0, 10);

        Lakes = new List<Lake>()
        {
            new("Vänern", 40),
            new("Vättern", 35),
            new("Hjälmaren", 30),
            new("Mälaren", 25),
            new("Storsjön", 20)
        };

        var lakeIndex = Rng.Next(0, 4);
        
        Lakes[lakeIndex].Fishes.Add(new Fish()
        {
            Name = "Sharknado",
                
            Weight = FishAttributes.Weight.Heavy,
            Speed = FishAttributes.Speed.Fast,
                
            Position = new Position(Lakes[lakeIndex].Size)
        });
        
        Lakes[lakeIndex].NumberOfFishes++;
    }
}