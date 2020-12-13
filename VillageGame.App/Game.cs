using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using VillageGame.App.Gui;
using VillageGame.App.States;
using VillageGame.App.Tiles;

namespace VillageGame.App
{
    class Game
    {
        private readonly TextureManager _textureManager = new TextureManager();
        private Dictionary<string, ITile> _tiles = new Dictionary<string, ITile>();
        private Dictionary<string, Font> _fonts = new Dictionary<string, Font>();
        private Dictionary<string, GuiStyle> _styles = new Dictionary<string, GuiStyle>();
        private IState _state;
        private const string _WindowName = "VillageGame";
        private const int _TileSize = 16;

        public RenderWindow Window { get; private set; }

        public Game(uint resolutionH, uint resolutionV)
        {
            LoadTextures();
            SetTiles();
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
                _textureManager.LoadTexture("emtpy", "Images/Empty.png");
                _textureManager.LoadTexture("grass", "Images/Grass.png");
                _textureManager.LoadTexture("water", "Images/Water.png");
            }
            catch
            {
                Console.WriteLine("Error: textures");
            }
        }

        private void LoadFonts()
        {
            try
            {
                var font = new Font("Fonts/Ratih Hyun.ttf");
                _fonts.Add("main", font);
            }
            catch
            {
                Console.WriteLine("Error: fonts");
            }
        }

        private void SetTiles()
        {
            _tiles.Add("empty", new Tile(_textureManager.GetTexture("emtpy"), TileType.Empty));
            _tiles.Add("grass", new Tile(_textureManager.GetTexture("grass"), TileType.Grass));
            _tiles.Add("water", new Tile(_textureManager.GetTexture("water"), TileType.Water));
        }

        private void SetStyles()
        {
            _styles.Add("button", new GuiStyle(new Vector2f(50f, 50f), _fonts["main"], new Color(0xc6, 0xc6, 0xc6),
                new Color(0x94, 0x94, 0x94), new Color(0x00, 0x00, 0x00), new Color(0x61, 0x61, 0x61),
                new Color(0x94, 0x94, 0x94), new Color(0x00, 0x00, 0x00), 10f));
            
            _styles.Add("text", new GuiStyle(new Vector2f(50f, 50f), _fonts["main"], new Color(0x00, 0x00, 0x00),
                new Color(0x00, 0x00, 0x00), new Color(0xff, 0xff, 0xff), new Color(0x00, 0x00, 0x00),
                new Color(0x00, 0x00, 0x00), new Color(0xff, 0xff, 0xff), 10f));
        }
    }
}
