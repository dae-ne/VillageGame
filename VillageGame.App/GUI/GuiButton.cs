using SFML.Graphics;
using SFML.System;

namespace VillageGame.App.GUI
{
    class GuiButton : GuiElement
    {
        public GuiButton(RectangleShape shape, Text text)
            : base(shape, text)
        { }    

        protected override IntRect GetRectOfShapePosition()
        {
            return new IntRect((int)_shape.Position.X,
                               (int)_shape.Position.Y,
                               (int)_shape.GetGlobalBounds().Width,
                               (int)_shape.GetGlobalBounds().Height);
        }

        protected override bool ContainsCursor(IntRect rect, Vector2f mousePosition)
        {
            return rect.Contains((int)mousePosition.X, (int)mousePosition.Y);
        }
    }
}
