using SFML.Graphics;
using SFML.System;

namespace VillageGame.App.Gui
{
    class GuiStyle
    {
        public Vector2f Dimensions { get; set; }
        public Color BodyColor { get; set; }
        public Color BodyHighlight { get; }
        public Color BodyHighlighColor { get; set; }
        public Color BorderColor { get; set; }
        public Color BorderHighlightColor { get; set; }
        public Color TextColor { get; set; }
        public Color TextHighlightColor { get; set; }
        public Font Font { get; set; }
        public float BorderThickness { get; set; }

        public GuiStyle() { }

        public GuiStyle(Vector2f dimensions,
                        Font font,
                        Color bodyColor,
                        Color bodyHighlight,
                        Color borderColor,
                        Color borderHighlightColor,
                        Color textColor,
                        Color textHighlightColor,
                        float borderThickness)
        {
            Dimensions = dimensions;
            Font = font;
            BodyColor = bodyColor;
            BodyHighlight = bodyHighlight;
            BorderColor = borderColor;
            BorderHighlightColor = borderHighlightColor;
            TextColor = textColor;
            TextHighlightColor = textHighlightColor;
            BorderThickness = borderThickness;
        }
    }
}
