using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using VillageGame.App.Tiles;
using VillageGame.App.Views;

namespace VillageGame.App.States
{
    class GameState : IState
    {
        private View _gameView = new View();
        private View _guiView = new View();
        private Map _map = new Map();
        private float _zoomLevel = 1.0f;

        public Game App { get; }

        public GameState(Game game, Dictionary<string, ITile> tiles)
        {
            App = game;
            var windowSizeUint = App.Window.Size;
            var x = (float)windowSizeUint.X;
            var y = (float)windowSizeUint.Y;
            var windowSize = new Vector2f(x, y);
            _gameView.Size = windowSize;
            _guiView.Size = windowSize;

            try
            {
                _ = _map.LoadFromFileAsync("Saves/empty.txt", tiles);
            }
            catch
            {
                throw;
            }
        }

        public void Draw()
        {
            App.Window.Clear();
            //App.Window.SetView(_guiView);
            //App.Window.SetView(_gameView);
            App.Window.Draw(_map);
            App.Window.Display();
        }

        public void HandleInput()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
