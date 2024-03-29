﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VillageGame.App.Tiles;

namespace VillageGame.App.Level
{
    class Map : Drawable
    {
        private List<ITile> _tiles = new List<ITile>();
        public const int TileSize = 16;

        public IEnumerable<ITile> Tiles => _tiles;
        public int Height { get; private set; }
        public int Width { get; private set; }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var position = new Vector2f();
                    position.X = x * TileSize;
                    position.Y = y * TileSize;
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
                            _tiles.Add(new Tile((Tile)tiles["grass1"]));
                            break;

                        case 1:
                            _tiles.Add(new Tile((Tile)tiles["grass2"]));
                            break;

                        case 2:
                            _tiles.Add(new Tile((Tile)tiles["path1"]));
                            break;

                        case 3:
                            _tiles.Add(new Tile((Tile)tiles["path2"]));
                            break;

                        case 4:
                            _tiles.Add(new Tile((Tile)tiles["water"]));
                            break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
