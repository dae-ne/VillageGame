using SFML.Graphics;

namespace VillageGame.App.GameStates
{
    class MenuState : IState
    {
        public Game App { get; }

        public View MenuView { get; }

        public MenuState(Game game)
        {
            App = game;
        }

        public void Draw()
        {
            App.Window.SetView(MenuView);
            App.Window.Clear();
            //App.Window.Draw();
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
