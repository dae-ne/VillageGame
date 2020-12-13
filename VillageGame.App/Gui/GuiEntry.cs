using SFML.Graphics;

namespace VillageGame.App.Gui
{
    class GuiEntry : Drawable
    {
        private RectangleShape _rectangle = new RectangleShape();

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_rectangle);
        }
    }
}
