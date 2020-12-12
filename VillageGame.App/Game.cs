using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using VillageGame.App.States;
using VillageGame.App.Tiles;

namespace VillageGame.App
{
    class Game
    {
        private List<IState> _states = new List<IState>();
        private readonly TextureManager _textureManager = new TextureManager();
        private Dictionary<string, ITile> _tiles = new Dictionary<string, ITile>();
        private const string _WindowName = "VillageGame";
        private const int _TileSize = 8;

        public RenderWindow Window { get; private set; }

        public Game(uint resolutionH, uint resolutionV)
        {
            LoadTextures();
            LoadTiles();
            Window = new RenderWindow(new VideoMode(resolutionH, resolutionV), _WindowName);
            Window.SetFramerateLimit(60);
        }

        public void GameLoop()
        {
            while (Window.IsOpen)
            {

            }
        }

        private void LoadTextures()
        {
            try
            {
                _textureManager.LoadTexture("grass", "Images/Grass.png");
            }
            catch
            {
                Console.WriteLine("Cannot load textures");
            }
        }

        private void LoadTiles()
        {
            _tiles.Add("grass", new Tile(_textureManager.GetTexture("grass")));
        }
    }
}
