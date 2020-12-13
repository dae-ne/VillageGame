using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VillageGame.App.Level
{
    class Map : Drawable
    {
        private int _height = 0;
        private int _width = 0;
        private int _tileSize = 8;
        private List<ITile> _tiles = new List<ITile>();

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var position = new Vector2f();
                    position.X = (x - y) * _tileSize + _width * _tileSize;
                    position.Y = (x + y) * _tileSize * 0.5f;
                    var currentIndex = y * _width + x;
                    _tiles[currentIndex].TileSprite.Position = position;
                    target.Draw(_tiles[currentIndex]);
                }
            }
        }

        public async Task LoadFromFileAsync(string path, Dictionary<string, ITile> tiles)
        {
            try
            {
                var fileText = await File.ReadAllTextAsync(path);
                var numbersAsStringArr = fileText.Split(' ').ToList();
                _width = Int32.Parse(numbersAsStringArr[0]);
                _height = Int32.Parse(numbersAsStringArr[1]);
                numbersAsStringArr.RemoveRange(0, 2);

                foreach (var numberStr in numbersAsStringArr)
                {
                    var number = Int32.Parse(numberStr);
                    _tiles.Add(tiles["grass"]);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task SaveToFileAsync()
        {
            var outputString = $"{_width} {_height}";

            foreach (var value in _tiles)
            {
                outputString += " 13";
            }

            try
            {
                using var file = new StreamWriter("Saves/" + DateTime.Now.ToString());
                await file.WriteAsync($"{_width} {_height}");
            }
            catch
            {
                throw;
            }
        }
    }
}
