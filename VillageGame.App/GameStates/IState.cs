namespace VillageGame.App.GameStates
{
    interface IState
    {
        Game App { get; }

        void Draw();
        void Update();
        void HandleInput();
    }
}
