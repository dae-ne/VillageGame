using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace VillageGame.App.Gui
{
    class GuiElement : Transformable, Drawable
    {
        public enum Direction { Horizontal, Vertical }

        private readonly List<GuiEntry> _entries = new List<GuiEntry>();
        private readonly GuiStyle _guiStyle;
        private readonly Direction _direction;

        public Vector2f SizeOfEntry { get; private set; }
        public int NumberOfEntries => _entries.Count;

        public GuiElement(IEnumerable<string> entries, GuiStyle style, Direction direction, Vector2f size)
        {
            _guiStyle = style;
            _direction = direction;
            SizeOfEntry = size;
            SetEntries(entries);
            SetPositionOfEntries();
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

        public void Highlight(GuiEntry entry)
        {
            entry.Shape.FillColor = _guiStyle.BodyHighlighColor;
            entry.Shape.OutlineColor = _guiStyle.BorderHighlightColor;
            entry.EntryText.FillColor = _guiStyle.TextHighlightColor;
        }

        public void UnHighlightAll()
        {
            foreach (var entry in _entries)
            {
                entry.Shape.FillColor = _guiStyle.BodyColor;
                entry.Shape.OutlineColor = _guiStyle.BorderColor;
                entry.EntryText.FillColor = _guiStyle.TextColor;
            }
        }

        public void SetSizeOfEntires(Vector2f size)
        {
            foreach (var entry in _entries)
            {
                entry.Shape.Size = size;
            }

            SizeOfEntry = size;
            SetPositionOfEntries();
        }

        public void Update()
        {
            SetPositionOfEntries();
            //UnHighlightAll();
        }

        private RectangleShape SetShape()
        {
            RectangleShape rectangle = new RectangleShape();
            rectangle.FillColor = _guiStyle.BodyColor;
            rectangle.OutlineThickness = _guiStyle.BorderThickness;
            rectangle.OutlineColor = _guiStyle.BorderColor;
            rectangle.Size = SizeOfEntry;
            return rectangle;
        }

        private void SetEntries(IEnumerable<string> entries)
        {
            foreach (var entry in entries)
            {
                var shape = SetShape();
                Text text = new Text(entry, _guiStyle.Font);
                text.FillColor = _guiStyle.TextColor;
                text.CharacterSize = (uint)(SizeOfEntry.Y - _guiStyle.BorderThickness);
                _entries.Add(new GuiEntry(shape, text));
            }
        }

        private void SetPositionOfEntries()
        {
            var offset = new Vector2f(0.0f, 0.0f);

            foreach (var entry in _entries)
            {
                var position = this.Position;
                position -= offset;
                entry.SetPosition(position);

                if (_direction == Direction.Horizontal)
                {
                    offset.X -= SizeOfEntry.X + _guiStyle.BorderThickness;
                }
                else
                {
                    offset.Y += SizeOfEntry.Y + _guiStyle.BorderThickness;
                }
            }
        }
    }
}
