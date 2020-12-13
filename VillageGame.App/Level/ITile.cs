using SFML.Graphics;

namespace VillageGame.App.Level
{
    interface ITile : Drawable
    {
        Sprite TileSprite { get; }
    }
}
