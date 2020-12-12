namespace VillageGame.App
{
    class EntryPoint
    {
        static void Main()
        {
            var game = new Game(800u, 600u);
            game.Run();
        }
    }
}
