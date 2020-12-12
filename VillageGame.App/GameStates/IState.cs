namespace VillageGame.App.GameStates
{
    interface IState
    {
        //    public:

        //Game* game;

        //    virtual void draw(const float dt) = 0;
        //    virtual void update(const float dt) = 0;
        //    virtual void handleInput() = 0;

        Game App { get; }

        void Draw();
        void Update();
        void HandleInput();
    }
}
