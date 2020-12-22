using SFML.Graphics;
using SFML.System;

namespace VillageGame.App.GUI
{
    class GuiStaticElement : GuiElement
    {
        public override bool IsEnabled { get => false; set => _ = value; }

        public GuiStaticElement(RectangleShape shape, Text text)
            : base(shape, text)
        { }

        protected override bool ContainsCursor(IntRect rect, Vector2f mousePosition)
        {
            return false;
        }

        protected override IntRect GetRectOfShapePosition()
        {
            return new IntRect();
        }
    }
}
