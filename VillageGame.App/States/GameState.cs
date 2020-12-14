using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;
using VillageGame.App.Level;
using VillageGame.App.Tiles;

namespace VillageGame.App.States
{
    class GameState : IState
    {
        private View _gameView = new View();
        private View _guiView = new View();
        private Map _map = new Map();
        private Vector2i _mousePosition = Mouse.GetPosition();
        private Vector2i _selectedTile = new Vector2i(-1, -1);
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
            SetEvents();

            try
            {
                _map.LoadFromFile("Saves/empty.txt", tiles);
            }
            catch
            {
                throw;
            }

            Vector2f centre = new Vector2f(_map.Width * 0.5f, _map.Height * 0.5f);
            centre *= 16.0f;
            _gameView.Center = centre;
        }

        public void Draw()
        {

            App.Window.Clear();
            //App.Window.SetView(_guiView);
            App.Window.SetView(_gameView);
            App.Window.Draw(_map);
            App.Window.Display();
        }

        public void Update()
        {
            for (int i = 0; i < _map.Tiles.Count(); i++)
            {
                _map.Tiles.ElementAt(i).TileSprite.Color = new Color(0xff, 0xff, 0xff);
            }

            if (_selectedTile.X >= 0 && _selectedTile.Y >= 0)
            {
                var index = _selectedTile.X + _map.Width * _selectedTile.Y;
                _map.Tiles.ElementAt(index).TileSprite.Color = new Color(0x7d, 0x7d, 0x7d);
            }
        }

        public void SetEvents()
        {
            App.Window.MouseButtonPressed += (sender, e) =>
            {
                if (e.Button == Mouse.Button.Left)
                {
                    _selectedTile.X = -1;
                    _selectedTile.Y = -1;

                    foreach (var tile in _map.Tiles)
                    {
                        Vector2f position = App.Window.MapPixelToCoords(Mouse.GetPosition(App.Window), _gameView);
                        _selectedTile.X = (int)(position.X / Map.TileSize);
                        _selectedTile.Y = (int)(position.Y / Map.TileSize);

                        if (_selectedTile.X >= _map.Width || _selectedTile.Y >= _map.Height)
                        {
                            _selectedTile.X = -1;
                            _selectedTile.Y = -1;
                        }
                    }
                }
            };

            App.Window.MouseMoved += (sender, e) =>
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Middle))
                {
                    var positionTmp = Mouse.GetPosition() - _mousePosition;
                    var position = new Vector2f((float)positionTmp.X, (float)positionTmp.Y);
                    _gameView.Move(-1.0f * position * _zoomLevel);
                }

                _mousePosition = Mouse.GetPosition();
            };

            App.Window.MouseWheelScrolled += (sender, e) =>
            {
                if (e.Delta < 0)
                {
                    _gameView.Zoom(1.25f);
                    _zoomLevel *= 1.25f;
                }
                else
                {
                    _gameView.Zoom(0.875f);
                    _zoomLevel *= 0.875f;
                }
            };

            App.Window.Resized += (sender, e) =>
            {
                _gameView.Size = new Vector2f(e.Width, e.Height);
                _gameView.Zoom(_zoomLevel);
            };
        }
    }
}
