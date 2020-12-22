using SFML.Graphics;
using SFML.System;

namespace VillageGame.App.GUI
{
    abstract class GuiElement : Drawable
    {
        protected readonly RectangleShape _shape;
        protected readonly Text _text;

        public RectangleShape Shape => _shape;
        public Text EntryText => _text;
        public virtual bool IsEnabled { get; set; } = true;

        protected GuiElement(RectangleShape shape, Text text)
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
            IntRect rect = GetRectOfShapePosition();
            return ContainsCursor(rect, mousePosition);
        }

        public void SetPosition(Vector2f position)
        {
            _shape.Position = position;
            _text.Position = position;
        }

        protected abstract IntRect GetRectOfShapePosition();
        protected abstract bool ContainsCursor(IntRect rect, Vector2f mousePosition);
    }
}
