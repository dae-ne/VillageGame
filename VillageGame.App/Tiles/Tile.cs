using SFML.Graphics;

namespace VillageGame.App.Tiles
{
    class Tile : ITile
    {
        private TileType _tileType;

        public Sprite TileSprite { get; } = new Sprite();

        public Tile(Texture texture, TileType tileType)
        {
            TileSprite.Texture = texture;
            _tileType = tileType;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(TileSprite);
        }
    }
}
