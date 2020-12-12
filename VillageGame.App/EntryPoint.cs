using SFML.Graphics;
using SFML.Window;
using System;

namespace VillageGame.App
{
    class EntryPoint
    {
        static void OnClose(object sender, EventArgs e)
        {
            var window = (RenderWindow)sender;
            window.Close();
        }

        static void Main()
        {
            var window = new RenderWindow(new VideoMode(800, 600), "SFML window");
            window.Closed += new EventHandler(OnClose);

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear();
                window.Display();
            }
        }
    }
}
