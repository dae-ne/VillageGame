using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace VillageGame.App.Gui
{
    class Gui : Transformable, Drawable
    {
        public enum Direction { Horizontal, Vertical }

        private readonly List<GuiEntry> _entries = new List<GuiEntry>();
        private readonly GuiStyle _guiStyle;
        private readonly Direction _direction;
        private readonly int _padding;

        public Gui(IEnumerable<string> entries, GuiStyle style, Direction direction, int padding)
        {
            _guiStyle = style;
            _direction = direction;
            _padding = padding;

            var shape = SetEntryShape(style);
            SetEntries(entries, style, shape);
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

        private RectangleShape SetEntryShape(GuiStyle style)
        {
            RectangleShape rectangle = new RectangleShape();
            rectangle.Size = style.Dimensions;
            rectangle.FillColor = style.BodyColor;
            rectangle.OutlineThickness = style.BorderThickness;
            rectangle.OutlineColor = style.BorderColor;
            return rectangle;
        }

        private void SetEntries(IEnumerable<string> entries, GuiStyle style, RectangleShape shape)
        {
            foreach (var entry in entries)
            {
                Text text = new Text(entry, style.Font);
                text.FillColor = style.TextColor;
                text.CharacterSize = (uint)(style.Dimensions.Y - style.BorderThickness - _padding);
                _entries.Add(new GuiEntry(shape, text));
            }
        }

        private void SetPositionOfEntries()
        {
            foreach (var entry in _entries)
            {
                //Vector2f origin = this->getOrigin();
                //origin -= offset;
                //entry.shape.setOrigin(origin);
                //entry.text.setOrigin(origin);

                ///* Compute the position of the entry. */
                //entry.shape.setPosition(this->getPosition());
                //entry.text.setPosition(this->getPosition());

                //if (this->horizontal) offset.x += this->dimensions.x;
                //else offset.y += this->dimensions.y;
            }
        }
    }
}
