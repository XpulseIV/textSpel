using The_game_of_doom.Classes.Game_classes.Fish_classes;
using The_game_of_doom.Classes.misc_classes;

namespace The_game_of_doom.Classes.Game_classes
{
    public sealed class VisualLake
    {
        private string _lakeName;
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
                System.Threading.Thread.Sleep(500);
            }
        }

        private bool DoAction(ref Game g)
        {
            g.PrintLakeTopMenu();
            this.ShowGrid(g);

            return false;
        }

        private void ShowGrid(Game g)
        {
            Console.SetCursorPosition(0, 8);
            List<string> infoBoxLines = new()
            {
                $"| CurrentLake: {this._lakeName} |",
                $"| Marker X: {this._markerX} |",
                $"| Marker Y: {this._markerY} |",
                $"| Player Money: {g.Player.Money} |",
            };

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
                        gridLineStr += " x ";
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