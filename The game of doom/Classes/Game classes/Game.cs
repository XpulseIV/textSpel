using The_game_of_doom.Classes.Game_classes.Fish_classes;
using The_game_of_doom.Classes.Game_classes.Player_classes;
using The_game_of_doom.Classes.Game_classes.Player_stuff;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes;

[Serializable]
public sealed class Game
{
    public Player Player;

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
                                       "7: Exit game", "1234567");

        var lakeIndex = int.Parse(placeToGo);
        
        switch (lakeIndex)
        {
            case < 6:
                //lakeLogic();
            
                goto ChoosePlace;
            case 6:
                ShopLogic();
            
                goto ChoosePlace;
            case 7:
                XmlFilerDeluxe.SaveGame(this);
                Environment.Exit(0);
                break;
        }
    }

    private void ShopLogic()
    {
        var choice = Asker.ForceKey("You have arrived at " + Shop.Name + ", do you want to enter? ", "YyNn");

        switch (choice)
        {
            case "Y" or "y":
                Console.WriteLine("Doorbell: Ding ding");
                Thread.Sleep(100);
                Console.WriteLine("Shop keep: What do you want to buy?");
                var selectedProduct = Hud.PrintShop(Player);

                break;
            case "N" or "n":
                return;
        }
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