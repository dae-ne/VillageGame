using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VillageGame.App.Tiles;

namespace VillageGame.App.Level
{
    class Map : Drawable
    {
        private int _tileSize = 16;
        private List<ITile> _tiles = new List<ITile>();

        public int Height { get; private set; }
        public int Width { get; private set; }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var position = new Vector2f();
                    position.X = x * _tileSize;
                    position.Y = y * _tileSize;
                    var currentIndex = y * Width + x;
                    _tiles[currentIndex].TileSprite.Position = position;
                    target.Draw(_tiles[currentIndex]);
                }
            }
        }

        public void LoadFromFile(string path, Dictionary<string, ITile> tiles)
        {
            try
            {
                var fileText = File.ReadAllText(path);
                var numbersAsStringArr = fileText.Split(' ').ToList();
                Width = Int32.Parse(numbersAsStringArr[0]);
                Height = Int32.Parse(numbersAsStringArr[1]);
                numbersAsStringArr.RemoveRange(0, 2);

                foreach (var numberStr in numbersAsStringArr)
                {
                    var number = Int32.Parse(numberStr);

                    switch (number)
                    {
                        case 0:
                            _tiles.Add(tiles["grass1"]);
                            break;

                        case 1:
                            _tiles.Add(tiles["grass2"]);
                            break;

                        case 2:
                            _tiles.Add(tiles["path1"]);
                            break;

                        case 3:
                            _tiles.Add(tiles["path2"]);
                            break;

                        case 4:
                            _tiles.Add(tiles["water"]);
                            break;

                        case 5:
                            _tiles.Add(tiles["tree1"]);
                            break;

                        case 6:
                            _tiles.Add(tiles["tree2"]);
                            break;

                        case 7:
                            _tiles.Add(tiles["tree3"]);
                            break;

                        case 8:
                            _tiles.Add(tiles["tree4"]);
                            break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task SaveToFileAsync()
        {
            var outputString = $"{Width} {Height}";

            foreach (var value in _tiles)
            {
                outputString += " 13";
            }

            try
            {
                using var file = new StreamWriter("Saves/" + DateTime.Now.ToString());
                await file.WriteAsync($"{Width} {Height}");
            }
            catch
            {
                throw;
            }
        }
    }
}
