namespace VillageGame.App.States
{
    interface IState
    {
        Game App { get; }

        void Draw();
        void Update();
        void SetEvents();
    }
}
