using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using VillageGame.App.GameStates;

namespace VillageGame.App
{
    class Game
    {
        private List<IState> _states = new List<IState>();
        private readonly TextureManager _textureManager = new TextureManager();
        private const string _WindowName = "VillageGame";

        private Sprite sprite;

        public RenderWindow Window { get; private set; }

        public Game(uint resolutionH, uint resolutionV)
        {
            LoadTextures();
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
    }
}
