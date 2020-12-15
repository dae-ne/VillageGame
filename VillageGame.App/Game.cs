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

        public RenderWindow Window { get; private set; }

        public Game(uint resolutionH, uint resolutionV)
        {
            LoadTextures();
            SetTiles();
            Window = new RenderWindow(new VideoMode(resolutionH, resolutionV), _WindowName);
            LoadFonts();
            SetStyles();
            SetStateAsGame();
        }

        public void Run()
        {
            Window.SetFramerateLimit(60);
            Window.SetActive();
            Window.Closed += (sender, e) => ((Window)sender).Close();

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                _state.Update();
                _state.Draw();
            }
        }

        public void SetStateAsGame()
        {
            _state = new GameState(this, _tiles, _styles["button"], _textureManager);
        }

        private void LoadTextures()
        {
            try
            {
                _textureManager.LoadTexture("ground", "Images/Ground.png");
                _textureManager.LoadTexture("buildings", "Images/Chapels.png");
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
                var font = new Font("Fonts/ArialUnicodeMS.ttf");
                _fonts.Add("main", font);
            }
            catch
            {
                Console.WriteLine("Error: fonts");
            }
        }

        private void SetTiles()
        {
            _tiles.Add("water", new Tile(_textureManager.GetTexture("ground"), TileType.Water, new Vector2i(0, 0)));
            _tiles.Add("grass1", new Tile(_textureManager.GetTexture("ground"), TileType.Empty, new Vector2i(1, 0)));
            _tiles.Add("grass2", new Tile(_textureManager.GetTexture("ground"), TileType.Empty, new Vector2i(2, 0)));
            _tiles.Add("path1", new Tile(_textureManager.GetTexture("ground"), TileType.Grass, new Vector2i(3, 0)));
            _tiles.Add("path2", new Tile(_textureManager.GetTexture("ground"), TileType.Grass, new Vector2i(4, 0)));
        }

        private void SetStyles()
        {
            _styles.Add("button", new GuiStyle(_fonts["main"], new Color(0xc6, 0xc6, 0xc6),
                new Color(0x00, 0x00, 0xff), new Color(0x00, 0x00, 0x00), new Color(0x61, 0x61, 0x61),
                new Color(0xff, 0xff, 0xff), new Color(0x94, 0x94, 0x94), 2.0f));
        }
    }
}
