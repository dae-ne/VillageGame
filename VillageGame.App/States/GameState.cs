using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;
using VillageGame.App.Gui;
using VillageGame.App.Level;
using VillageGame.App.Tiles;

namespace VillageGame.App.States
{
    class GameState : IState
    {
        private View _gameView = new View();
        private View _guiView = new View();
        private Map _map = new Map();
        private GuiElement _gui;
        private GuiElement _gui2;
        private Vector2i _mousePosition = Mouse.GetPosition();
        private Vector2i _selectedTile = new Vector2i(-1, -1);
        private float _zoomLevel = 0.20f;
        private GuiEntry _selectedGuiEntry = null;
        private readonly TextureManager _textureManager;
        private Village _village = new Village();
        private VillageCareTaker _careTaker = new VillageCareTaker();
        private Clock _clock = new Clock();

        public Game App { get; }

        public GameState(Game game, Dictionary<string, ITile> tiles, GuiStyle style, TextureManager textureManager)
        {
            App = game;
            _textureManager = textureManager;
            var windowSizeUint = App.Window.Size;
            var x = (float)windowSizeUint.X;
            var y = (float)windowSizeUint.Y;
            var windowSize = new Vector2f(x, y);
            _gameView.Size = windowSize;
            _guiView.Size = windowSize;
            _gameView.Zoom(_zoomLevel);
            SetEvents();
            SetGui(style);

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
            _guiView.Reset(new FloatRect(0, 0, App.Window.Size.X, App.Window.Size.Y));
        }

        public void Draw()
        {
            App.Window.Clear();
            App.Window.SetView(_gameView);
            App.Window.Draw(_map);
            App.Window.SetView(_guiView);
            App.Window.Draw(_gui);
            App.Window.Draw(_gui2);
            App.Window.Display();
        }

        public void Update()
        {
            _gui.Update();
            _gui2.Update();
            _gui.UnHighlightAll();

            _gui2.SetTextOfEntry(0, $"Kasa: {_village.Money} zł");
            _gui2.SetTextOfEntry(1, $"Czas: {(int)_clock.ElapsedTime.AsSeconds()} s");

            if (_selectedGuiEntry != null)
            {
                _gui.Highlight(_selectedGuiEntry);
            }

            foreach (var tile in _map.Tiles)
            {
                tile.TileSprite.Color = new Color(0xff, 0xff, 0xff);
            }

            if (_selectedTile.X >= 0 && _selectedTile.Y >= 0)
            {
                var index = _selectedTile.X + _map.Width * _selectedTile.Y;
                _map.Tiles.ElementAt(index).TileSprite.Color = new Color(0x7d, 0x7d, 0x7d);
            }
        }

        public void SetEvents()
        {
            App.Window.KeyPressed += (sender, e) =>
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.LControl) && Keyboard.IsKeyPressed(Keyboard.Key.Z))
                {
                    var momento = _careTaker.Pop();

                    if (momento != null)
                    {
                        _village.RestoreStateFromMomento(momento);
                    }
                }
            };

            App.Window.MouseButtonPressed += (sender, e) =>
            {
                if (e.Button == Mouse.Button.Left)
                {
                    var mousePosition = new Vector2f(e.X, e.Y);
                    var entry = _gui.GetSelectedEntry(mousePosition);

                    if (_selectedTile.X >= 0 || _selectedTile.Y >= 0)
                    {
                        if (entry != null)
                        {
                            var indexOfEntry = _gui.GetIndexOfEntry(entry);
                            var indexOfTile = _selectedTile.X + _map.Width * _selectedTile.Y;
                            var momento = _village.SaveStateToMomento();

                            switch (indexOfEntry)
                            {
                                case 0:
                                    if (_village.BuildQuarry())
                                    {
                                        _careTaker.Push(momento);
                                        _map.Tiles.ElementAt(indexOfTile).AddObject(_textureManager.GetTexture("buildings"), new Vector2i(0, 0));
                                    }
                                    break;

                                case 1:
                                    if (_village.BuildSawmill())
                                    {
                                        _careTaker.Push(momento);
                                        _map.Tiles.ElementAt(indexOfTile).AddObject(_textureManager.GetTexture("buildings"), new Vector2i(0, 0));
                                    }
                                    break;

                                case 2:
                                    if (_village.BuildCottage())
                                    {
                                        _careTaker.Push(momento);
                                        _map.Tiles.ElementAt(indexOfTile).AddObject(_textureManager.GetTexture("buildings"), new Vector2i(0, 0));
                                    }
                                    break;

                                case 3:
                                    if (_village.BuildGoldMine())
                                    {
                                        _careTaker.Push(momento);
                                        _map.Tiles.ElementAt(indexOfTile).AddObject(_textureManager.GetTexture("buildings"), new Vector2i(0, 0));
                                    }
                                    break;

                                case 4:
                                    if (_village.BuildMint())
                                    {
                                        _careTaker.Push(momento);
                                        _map.Tiles.ElementAt(indexOfTile).AddObject(_textureManager.GetTexture("buildings"), new Vector2i(0, 0));
                                    }
                                    break;
                            }

                            _selectedTile.X = -1;
                            _selectedTile.Y = -1;
                        }
                    }
                    if (entry == null)
                    {
                        _selectedTile.X = -1;
                        _selectedTile.Y = -1;

                        foreach (var tile in _map.Tiles)
                        {
                            var position = App.Window.MapPixelToCoords(Mouse.GetPosition(App.Window), _gameView);
                            var x = position.X / Map.TileSize;
                            var y = position.Y / Map.TileSize;

                            if (x < 0 || y < 0)
                            {
                                _selectedTile.X = -1;
                                _selectedTile.Y = -1;
                            }
                            else
                            {
                                _selectedTile.X = (int)(position.X / Map.TileSize);
                                _selectedTile.Y = (int)(position.Y / Map.TileSize);

                                var indexOfTile = _selectedTile.X + _map.Width * _selectedTile.Y;

                                if (_map.Tiles.ElementAt(indexOfTile).HasObject)
                                {
                                    _selectedTile.X = -1;
                                    _selectedTile.Y = -1;
                                }
                            }

                            if (_selectedTile.X >= _map.Width || _selectedTile.Y >= _map.Height)
                            {
                                _selectedTile.X = -1;
                                _selectedTile.Y = -1;
                            }
                        }
                    }
                }
            };

            App.Window.MouseMoved += (sender, e) =>
            {
                _selectedGuiEntry = null;
                var isOverGui = false;
                var mousePosition = new Vector2f(e.X, e.Y);
                var entry = _gui.GetSelectedEntry(mousePosition);

                if (entry != null)
                {
                    isOverGui = true;
                    _selectedGuiEntry = entry;
                }

                if (Mouse.IsButtonPressed(Mouse.Button.Middle) && !isOverGui)
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
                _guiView.Reset(new FloatRect(0, 0, e.Width, e.Height));
                _gameView.Zoom(_zoomLevel);
                _gui.Position = new Vector2f(0, e.Height - 2 * _gui.SizeOfEntry.Y);
                _gui2.Position = new Vector2f(0, e.Height - _gui.SizeOfEntry.Y);
                _gui2.SetSizeOfEntires(new Vector2f(e.Width / _gui2.NumberOfEntries, _gui2.SizeOfEntry.Y));
            };
        }

        private void SetGui(GuiStyle style)
        {
            var entries = new[] {
                "Kamieniołom: 500 zł",
                "Tartak: 3000 zł",
                "Chatka drwala: 1500zł",
                "Kopalnia złota: 5000 zł",
                "Mennica: 10000 zł"
            };

            var entries2 = new[] {
                "",
                ""
            };

            _gui = new GuiElement(entries, style, GuiElement.Direction.Vertical, new Vector2f(300, 30));
            _gui2 = new GuiElement(entries2, style, GuiElement.Direction.Horizontal, new Vector2f(300, 30));
            _gui.Position = new Vector2f(0, App.Window.Size.Y - 2 * _gui.SizeOfEntry.Y);
            _gui2.Position = new Vector2f(0, App.Window.Size.Y - _gui.SizeOfEntry.Y);
            _gui2.SetSizeOfEntires(new Vector2f(App.Window.Size.X / _gui2.NumberOfEntries, _gui2.SizeOfEntry.Y));
        }
    }
}
