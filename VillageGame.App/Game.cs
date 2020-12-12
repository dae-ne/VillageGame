using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using VillageGame.App.GameStates;

namespace VillageGame.App
{
    class Game
    {
        private List<IState> _states;
        //private RenderWindow window;
        private const string _WindowName = "VillageGame";

        public RenderWindow Window { get; private set; }

        public Game(uint resolutionH, uint resolutionV)
        {
            Window = new RenderWindow(new VideoMode(resolutionH, resolutionV), WindowName);
        }

        public void GameLoop()
        {
            while (Window.IsOpen)
            {

            }
        }
    }
}
