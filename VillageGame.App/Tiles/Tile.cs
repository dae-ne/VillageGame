using SFML.Graphics;

namespace VillageGame.App.Tiles
{
    class Tile : ITile
    {
        public Sprite TileSprite { get; }

        public Tile(Texture texture)
        {
            TileSprite.Texture = texture;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(TileSprite);
        }
    }
}
