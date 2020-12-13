using SFML.Graphics;
using SFML.System;

namespace VillageGame.App.Tiles
{
    class Tile : ITile
    {
        private TileType _tileType;
        private Vector2i _partOfTexture;
        //private float _tileSizeinPixels = 16;
        //private int _tileSize = 1;

        public Sprite TileSprite { get; } = new Sprite();

        public Tile(Texture texture, TileType tileType, Vector2i partOfTexture)
        {
            TileSprite.Texture = texture;
            TileSprite.TextureRect = new IntRect(partOfTexture.X * 16, partOfTexture.Y * 16, 16, 16);
            _tileType = tileType;
            _partOfTexture = partOfTexture;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(TileSprite);
        }
    }
}
