using SFML.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace VillageGame.App.Gui
{
    class Gui : Transformable, Drawable
    {
        public enum Direction { Horizontal, Vertical }

        private readonly List<GuiEntry> _entries;
        private readonly GuiStyle _guiStyle;
        private readonly Direction _direction;
        private readonly int _padding;

        public Gui(IEnumerable<GuiEntry> entries, GuiStyle style, Direction direction, int padding)
        {
            _entries = entries.ToList();
            _guiStyle = style;
            _direction = direction;
            _padding = padding;

            var background = SetBackground(style);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            throw new System.NotImplementedException();
        }

        private RectangleShape SetBackground(GuiStyle style)
        {
            RectangleShape rectangle = new RectangleShape();
            rectangle.Size = style.Dimensions;
            rectangle.FillColor = style.BodyColor;
            rectangle.OutlineThickness = style.BorderThickness;
            rectangle.OutlineColor = style.BorderColor;
            return rectangle;
        }

        private void SetEntries(GuiStyle style)
        {
            foreach (var entry in _entries)
            {

            }
        }
    }
}
