using SFML.Graphics;

namespace VillageGame.App.Tiles
{
    interface ITile : Drawable
    {
        Sprite TileSprite { get; }
    }
}
