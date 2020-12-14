using SFML.Graphics;

namespace VillageGame.App.Gui
{
    class GuiStyle
    {
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

        public GuiStyle(Font font,
                        Color bodyColor,
                        Color bodyHighlight,
                        Color borderColor,
                        Color borderHighlightColor,
                        Color textColor,
                        Color textHighlightColor,
                        float borderThickness)
        {
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
