using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace VillageGame.App.Gui
{
    class GuiElement : Transformable, Drawable
    {
        public enum Direction { Horizontal, Vertical }

        private readonly List<GuiEntry> _entries = new List<GuiEntry>();
        //private readonly GuiStyle _guiStyle;
        private readonly Direction _direction;
        private readonly int _padding;

        public GuiElement(IEnumerable<string> entries, GuiStyle style, Direction direction, Vector2f size)
        {
            //_guiStyle = style;
            _direction = direction;

            //var shape = SetShape(style, size);
            SetEntries(entries, style, size);
            SetPositionOfEntries(style, size);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var entry in _entries)
            {
                target.Draw(entry);
            }
        }

        public GuiEntry GetSelectedEntry(Vector2f mousePosition)
        {
            foreach (var entry in _entries)
            {
                if (entry.Contains(mousePosition))
                {
                    return entry;
                }
            }

            return null;
        }

        private RectangleShape SetShape(GuiStyle style, Vector2f size)
        {
            RectangleShape rectangle = new RectangleShape();
            rectangle.FillColor = style.BodyColor;
            rectangle.OutlineThickness = style.BorderThickness;
            rectangle.OutlineColor = style.BorderColor;
            rectangle.Size = size;
            return rectangle;
        }

        private void SetEntries(IEnumerable<string> entries, GuiStyle style, Vector2f size)
        {
            foreach (var entry in entries)
            {
                var shape = SetShape(style, size);
                Text text = new Text(entry, style.Font);
                text.FillColor = style.TextColor;
                text.CharacterSize = (uint)(size.Y - style.BorderThickness);
                _entries.Add(new GuiEntry(shape, text));
            }
        }

        private void SetPositionOfEntries(GuiStyle style, Vector2f size)
        {
            var offset = new Vector2f(0.0f, 0.0f);

            foreach (var entry in _entries)
            {
                var position = this.Position;
                position -= offset;
                entry.SetPosition(position);

                if (_direction == Direction.Horizontal)
                {
                    offset.X += size.X + style.BorderThickness;
                }
                else
                {
                    offset.Y -= size.Y + style.BorderThickness;
                }
            }
        }
    }
}
