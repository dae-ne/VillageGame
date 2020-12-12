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
        private readonly TextureManager _textureManager = new TextureManager();
        private Dictionary<string, ITile> _tiles = new Dictionary<string, ITile>();
        private IState _state;
        private const string _WindowName = "VillageGame";
        private const int _TileSize = 8;

        public RenderWindow Window { get; private set; }

        public Game(uint resolutionH, uint resolutionV)
        {
            LoadTextures();
            LoadTiles();
            Window = new RenderWindow(new VideoMode(resolutionH, resolutionV), _WindowName);
        }

        public void Run()
        {
            Window.SetFramerateLimit(60);
            Window.SetActive();
            Window.Closed += (sender, e) => ((Window)sender).Close();
            SetStateAsGame();

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                //_state.Update();
                _state.Draw();
            }
        }

        public void SetStateAsGame()
        {
            _state = new GameState(this, _tiles);
        }

        public void SetStateAsMenu()
        {
            _state = new MenuState(this);
        }

        private void LoadTextures()
        {
            try
            {
                _textureManager.LoadTexture("grass", "Grass.png");
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
