using SFML.Graphics;
using SFML.System;

namespace VillageGame.App.GUI
{
    class GuiEntry : Drawable
    {
        private readonly RectangleShape _shape;
        private readonly Text _text;

        public RectangleShape Shape => _shape;
        public Text EntryText => _text;

        public GuiEntry(RectangleShape shape, Text text)
        {
            _shape = shape;
            _text = text;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_shape);
            target.Draw(_text);
        }

        public bool Contains(Vector2f mousePosition)
        {
            IntRect rect = new IntRect((int)_shape.Position.X,
                                       (int)_shape.Position.Y,
                                       (int)_shape.GetGlobalBounds().Width,
                                       (int)_shape.GetGlobalBounds().Height);

            return rect.Contains((int)mousePosition.X, (int)mousePosition.Y);
        }

        public void SetPosition(Vector2f position)
        {
            _shape.Position = position;
            _text.Position = position;
        }
    }
}
