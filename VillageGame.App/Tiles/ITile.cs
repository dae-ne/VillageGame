using SFML.Graphics;
using SFML.System;

namespace VillageGame.App.Tiles
{
    interface ITile : Drawable
    {
        Sprite TileSprite { get; }
        Sprite Object { get; }
        bool HasObject { get; }

        void AddObject(Texture texture, Vector2i partOfTexture);
    }
}
