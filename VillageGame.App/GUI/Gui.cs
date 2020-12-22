using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Linq;

namespace VillageGame.App.GUI
{
    class Gui : Transformable, Drawable
    {
        public enum Direction { Horizontal, Vertical }

        private readonly List<GuiElement> _entries = new List<GuiElement>();
        private readonly GuiStyle _guiStyle;
        private readonly Direction _direction;

        public Vector2f SizeOfEntry { get; private set; }
        public int NumberOfEntries => _entries.Count;

        public Gui(IEnumerable<string> entries, GuiStyle style, Direction direction, Vector2f size, bool enabled = true)
        {
            _guiStyle = style;
            _direction = direction;
            SizeOfEntry = size;
            SetEntries(entries, enabled);
            SetPositionOfEntries();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var entry in _entries)
            {
                target.Draw(entry);
            }
        }

        public int GetIndexOfEntry(GuiElement entry)
        {
            return _entries.IndexOf(entry);
        }

        public GuiElement GetSelectedEntry(Vector2f mousePosition)
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

        public void SetEntryAsEnabled(int index)
        {
            _entries[index].IsEnabled = true;
        }

        public void SetEntryAsDisabled(int index)
        {
            _entries[index].IsEnabled = false;
        }

        public bool IsEntryEnabled(int index)
        {
            return _entries[index].IsEnabled;
        }

        public void SetTextOfEntry(int index, string text)
        {
            _entries.ElementAt(index).EntryText.DisplayedString = text;
        }

        public void Highlight(GuiElement entry)
        {
            entry.Shape.FillColor = _guiStyle.BodyHighlightColor;
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

        private void SetEntries(IEnumerable<string> entries, bool enabled)
        {
            foreach (var entry in entries)
            {
                var shape = SetShape();
                Text text = new Text(entry, _guiStyle.Font);
                text.FillColor = _guiStyle.TextColor;
                text.CharacterSize = (uint)(SizeOfEntry.Y - _guiStyle.BorderThickness);

                if (enabled)
                {
                    _entries.Add(new GuiButton(shape, text));
                }
                else
                { 
                    _entries.Add(new GuiStaticElement(shape, text));
                }
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
