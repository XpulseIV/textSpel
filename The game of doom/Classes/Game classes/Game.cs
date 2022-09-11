using The_game_of_doom.Classes.Game_classes.Fish_classes;
using The_game_of_doom.Classes.Game_classes.Player_classes;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes;

[Serializable]
public class Game
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
                                       "6: To the shop\n", "123456");

        var lakeIndex = -1;
        switch (placeToGo)
        {
            case "1":
                lakeIndex = 0;
                break;
            case "2":
                lakeIndex = 1;
                break;
            case "3":
                lakeIndex = 2;
                break;
            case "4":
                lakeIndex = 3;
                break;
            case "5":
                lakeIndex = 4;
                break;
            case "6":
                ShopLogic();
                
                goto ChoosePlace;
            case "7":
                //Go back to place selection
            break;
        }

        if (lakeIndex != -1)
        {
            //lakeLogic();
            
            goto ChoosePlace;
        }
        
        XmlFilerDeluxe.SaveGame(this);
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
                Shop.PrintItems();
                
                
                
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
        Player = new Player(0);

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