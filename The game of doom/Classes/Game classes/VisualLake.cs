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

        private Tuple<int, bool>[,] _fishMap;

        internal void Loop(ref Game game)
        {
            bool exit = false;
            while (exit != true)
            {
                exit = this.DoAction(ref game);
            }
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

                    if (this._markerY >= (this._lakeSize)) this._markerY = 0;

                    break;

                case ConsoleKey.F:
                    throw new NotImplementedException();

                case ConsoleKey.E:
                    Console.Clear();
                    return true;

                default:
                    throw new ArgumentOutOfRangeException();
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

            int longestStr = infoBoxLines.Max((str) => str.Length);


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
                "[Arrow keys for movement]",
                "[Press F to fish        ]"
            };

            if (g.Player.Equipment.La.RadarType != Equipment.LookingAid.None) keybindStrs.Add("[Press R to use radar   ]");

            keybindStrs.Add("[Press E to exit        ]");

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
                    this._fishMap[x, y] = new Tuple<int, bool>(amountOfFishesAtPosition, true);
                }
            }
        }

        internal VisualLake(string lakeName, int lakeSize)
        {
            this._lakeName = lakeName;
            this._lakeSize = lakeSize;
            this._markerX = 0;
            this._markerY = 0;

            this._fishMap = new Tuple<int, bool>[0, 0];
        }
    }
}