using SFML.Graphics;

namespace VillageGame.App.Tiles
{
    class Tile : ITile
    {
        private Sprite _sprite = new Sprite();

        public Tile(Texture texture)
        {
            _sprite.Texture = texture;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            throw new System.NotImplementedException();
        }
    }
}
