using The_game_of_doom.Classes.Game_classes.Fish_classes;
using The_game_of_doom.Classes.Game_classes.Player_stuff;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes
{
    public sealed class VisualLake
    {
        private readonly string _lakeName;
        private int _markerX;
        private int _markerY;
        private readonly int _lakeSize;
        private readonly Random _random;

        private Tuple<int, bool>[,] _fishMap;

        internal void Loop(ref Game game)
        {
            bool exit = false;
            while (exit != true) exit = this.DoAction(ref game);
        }

        private bool DoAction(ref Game g)
        {
            this.ShowGrid(g);

        yes:
            ConsoleKeyInfo pressedKey = Console.ReadKey();

            switch (pressedKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    this._markerX--;

                    if (this._markerX <= -1) this._markerX = this._lakeSize - 1;

                    break;

                case ConsoleKey.RightArrow:
                    this._markerX++;

                    if (this._markerX >= this._lakeSize) this._markerX = 0;

                    break;

                case ConsoleKey.UpArrow:
                    this._markerY--;

                    if (this._markerY <= -1) this._markerY = this._lakeSize - 1;

                    break;

                case ConsoleKey.DownArrow:
                    this._markerY++;

                    if (this._markerY >= this._lakeSize) this._markerY = 0;

                    break;

                case ConsoleKey.F:
                    throw new NotImplementedException();

                case ConsoleKey.R:
                    if (g.Player.Equipment.La.RadarType == Equipment.LookingAid.None) break;

                    int lakeIndex1 = g.Lakes.FindAllIndex(lake => lake.Name == this._lakeName)[0];

                    List<Fish> foundFishesInRadius = g.Player.Equipment.La.RadarType switch
                    {
                        Equipment.LookingAid.RadarT1 => (from fish in g.Lakes[lakeIndex1].Fishes
                            let distanceToLookPosition =
                                Math.Sqrt(Math.Pow(this._markerX - fish.Position.PosX, 2) + Math.Pow(this._markerY - fish.Position.PosY, 2))
                            where Math.Abs(distanceToLookPosition - 2) <= 0.5
                            select fish).ToList(),
                        Equipment.LookingAid.RadarT2 => (from fish in g.Lakes[lakeIndex1].Fishes
                            let distanceToLookPosition =
                                Math.Sqrt(Math.Pow(this._markerX - fish.Position.PosX, 2) + Math.Pow(this._markerY - fish.Position.PosY, 2))
                            where Math.Abs(distanceToLookPosition - 4) <= 0.5
                            select fish).ToList(),
                        Equipment.LookingAid.RadarT3 => (from fish in g.Lakes[lakeIndex1].Fishes
                            let distanceToLookPosition =
                                Math.Sqrt(Math.Pow(this._markerX - fish.Position.PosX, 2) + Math.Pow(this._markerY - fish.Position.PosY, 2))
                            where Math.Abs(distanceToLookPosition - 6) <= 0.5
                            select fish).ToList(),
                        Equipment.LookingAid.RadarT4 => (from fish in g.Lakes[lakeIndex1].Fishes
                            let distanceToLookPosition =
                                Math.Sqrt(Math.Pow(this._markerX - fish.Position.PosX, 2) + Math.Pow(this._markerY - fish.Position.PosY, 2))
                            where Math.Abs(distanceToLookPosition - 8) <= 0.5
                            select fish).ToList(),
                        Equipment.LookingAid.RadarT5 => (from fish in g.Lakes[lakeIndex1].Fishes
                            let distanceToLookPosition =
                                Math.Sqrt(Math.Pow(this._markerX - fish.Position.PosX, 2) + Math.Pow(this._markerY - fish.Position.PosY, 2))
                            where Math.Abs(distanceToLookPosition - 10) <= 0.5
                            select fish).ToList(),
                        _ => new List<Fish>
                        {
                            Capacity = 0
                        }
                    };

                    foreach (Fish fish in foundFishesInRadius)
                    {
                        this._fishMap[fish.Position.PosX, fish.Position.PosY] =
                            new Tuple<int, bool>(this._fishMap[fish.Position.PosX, fish.Position.PosY].Item1, true);
                    }


                    g.Player.Equipment.La = new Radar(g.Player.Equipment.La.RadarType, g.Player.Equipment.La.Uses - 1);

                    if (g.Player.Equipment.La.Uses == 0)
                    {
                        g.Player.OwnedRadars.Remove(g.Player.Equipment.La);
                        g.Player.Equipment.La = new Radar(Equipment.LookingAid.None);
                        this.ShowGrid(g);
                        break;
                    }

                    double chanceOfBreaking = g.Player.Equipment.La.Lerp();
                    bool breakRadar = this._random.Next(0, 100) < chanceOfBreaking;

                    if (breakRadar)
                    {
                        g.Player.OwnedRadars.Remove(g.Player.Equipment.La);
                        g.Player.Equipment.La = new Radar(Equipment.LookingAid.None);
                        this.ShowGrid(g);
                    }

                    this.ShowGrid(g);

                    break;


                case ConsoleKey.E:
                    Console.Clear();

                    int lakeIndex2 = g.Lakes.FindAllIndex(lake => lake.Name == this._lakeName)[0];

                    foreach (Fish t in g.Lakes[lakeIndex2].Fishes)
                        t.Position = t.Position.Move((int)t.Speed, g.Lakes[lakeIndex2].Size);

                    this.GenerateFishMap(g.Lakes[lakeIndex2].Fishes);

                    return true;

                default:
                    goto yes;
            }

            return false;
        }

        private void ShowGrid(Game g)
        {
            g.PrintLakeTopMenu();

            List<string> infoBoxLines = new()
            {
                $"| Current Lake: {this._lakeName} |",
                $"| Marker X: {this._markerX} |",
                $"| Marker Y: {this._markerY} |"
            };

            int longestStr = infoBoxLines.Max(static str => str.Length);


            for (int i = 0; i < infoBoxLines.Count; i++)
            {
                if (infoBoxLines[i].Length == longestStr) continue;

                do
                    infoBoxLines[i] = infoBoxLines[i].Insert(infoBoxLines[i].Length - 1, " ");
                while (infoBoxLines[i].Length != longestStr);
            }

            for (int y = 0; y < infoBoxLines.Count; y++)
            {
                Console.SetCursorPosition(0, y + 8);
                Console.Write(infoBoxLines[y]);
            }

            List<string> gridLines = new();
            string gridLineStr = "";

            for (int y = 0; y < this._lakeSize; y++)
            {
                gridLineStr += '|';

                for (int x = 0; x < this._lakeSize; x++)
                {
                    if ((x, y) == (this._markerX, this._markerY))
                    {
                        if ((this._fishMap[x, y].Item1 > 0) && this._fishMap[x, y].Item2)
                        {
                            gridLineStr += " u ";
                            continue;
                        }

                        gridLineStr += " i ";
                        continue;
                    }

                    if ((this._fishMap[x, y].Item1 == 0) || ((this._fishMap[x, y].Item1 > 0) && (this._fishMap[x, y].Item2 == false)))
                    {
                        gridLineStr += "   ";
                        continue;
                    }

                    gridLineStr += " o ";
                }

                gridLineStr += '|';
                gridLines.Add(gridLineStr);

                gridLineStr = "";
            }

            for (int y = 0; y < gridLines.Count; y++)
            {
                Console.SetCursorPosition((Console.WindowWidth - ((this._lakeSize * 3) + 2)) / 2, y + 8);
                Console.Write(gridLines[y]);
            }

            List<string> keybindStrs = new()
            {
                "| Arrow keys for movement |",
                "| Press F to fish         |"
            };

            if (g.Player.Equipment.La.RadarType != Equipment.LookingAid.None) keybindStrs.Add("| Press R to use radar    |");

            keybindStrs.Add("| Press E to exit         |");

            for (int y = 0; y < keybindStrs.Count; y++)
            {
                Console.SetCursorPosition(Console.WindowWidth - keybindStrs[0].Length, y + 8);
                Console.Write(keybindStrs[y]);
            }
        }

        internal void GenerateFishMap(List<Fish> fishList)
        {
            this._fishMap = new Tuple<int, bool>[this._lakeSize, this._lakeSize];

            for (int y = 0; y < this._lakeSize; y++)
            {
                for (int x = 0; x < this._lakeSize; x++)
                {
                    int x1 = x;
                    int y1 = y;
                    int amountOfFishesAtPosition = fishList.FindAllIndex(fish => (fish.Position.PosX == x1) && (fish.Position.PosY == y1)).Length;
                    this._fishMap[x, y] = new Tuple<int, bool>(amountOfFishesAtPosition, false);
                }
            }
        }

        internal VisualLake(string lakeName, int lakeSize)
        {
            this._lakeName = lakeName;
            this._lakeSize = lakeSize;
            this._random = new Random();
            this._markerX = 0;
            this._markerY = 0;

            this._fishMap = new Tuple<int, bool>[0, 0];
        }
    }
}