using SFML.Graphics;
using System;

namespace VillageGame.App.Tiles
{
    interface ITile : Drawable
    {
        Sprite TileSprite { get; }
    }
}
