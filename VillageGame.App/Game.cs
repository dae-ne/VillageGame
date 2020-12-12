using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using VillageGame.App.GameStates;

namespace VillageGame.App
{
    class Game
    {
        private List<IState> states;
        private RenderWindow window;
        private const string WindowName = "VillageGame";

        public Game(uint resolutionH, uint resolutionV)
        {
            window = new RenderWindow(new VideoMode(resolutionH, resolutionV), WindowName);
        }

        public void GameLoop()
        {
            while (window.IsOpen)
            {

            }
        }
    }
}
