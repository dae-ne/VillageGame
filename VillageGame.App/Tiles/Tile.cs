using SFML.Graphics;
using SFML.System;

namespace VillageGame.App.Tiles
{
    class Tile : ITile
    {
        private TileType _tileType;
        private Vector2i _partOfTexture;

        public Sprite TileSprite { get; } = new Sprite();
        public Sprite Object { get; } = new Sprite();
        public bool HasObject { get; private set; } = false;

        public Tile(Texture texture, TileType tileType, Vector2i partOfTexture)
        {
            TileSprite.Texture = texture;
            TileSprite.TextureRect = new IntRect(partOfTexture.X * 16, partOfTexture.Y * 16, 16, 16);
            _tileType = tileType;
            _partOfTexture = partOfTexture;
        }

        public Tile(Tile tile)
            : this(tile.TileSprite.Texture, tile._tileType, tile._partOfTexture)
        {
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(TileSprite);
            target.Draw(Object);
        }

        public void AddObject(Texture texture, Vector2i partOfTexture)
        {
            Object.Texture = texture;
            HasObject = true;
            Object.TextureRect = new IntRect(partOfTexture.X * 16, partOfTexture.Y * 16, 16, 16);
            Object.Position = TileSprite.Position;
        }
    }
}
