using SFML.Graphics;

namespace VillageGame.App.Gui
{
    interface IGuiStyle
    {
        public Color BodyColor { get; set; }
        public Color BodyHighlighColor { get; set; }
        public Color BorderColor { get; set; }
        public Color BorderHighlightColor { get; set; }
        public Color TextColor { get; set; }
        public Color TextHighlightColor { get; set; }
        public Font Font { get; set; }

        public void InitStyle(Font font,
                              Color bodyColor,
                              Color bodyHighlight,
                              Color borderColor,
                              Color borderColorHighlightColor,
                              Color textColor,
                              Color textHighlightColor);
    }
}
