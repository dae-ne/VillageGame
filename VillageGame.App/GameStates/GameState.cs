namespace VillageGame.App.GameStates
{
    class GameState : IState
    {
        public Game App { get; }

        public GameState(Game game)
        {
            App = game;
        }

        public void Draw()
        {
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
