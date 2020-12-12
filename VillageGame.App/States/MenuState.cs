using SFML.Graphics;

namespace VillageGame.App.States
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
