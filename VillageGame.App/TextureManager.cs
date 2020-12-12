using SFML.Graphics;
using System.Collections.Generic;

namespace VillageGame.App
{
    class TextureManager
    {
        private Dictionary<string, Texture> _textures = new Dictionary<string, Texture>();

        public void LoadTexture(string name, string path)
        {
            try
            {
                _textures.Add(name, new Texture(path));
            }
            catch
            {
                throw;
            }
        }


        public Texture GetTexture(string name)
        {
            try
            {
                return _textures[name];
            }
            catch
            {
                throw;
            }
        }
    }
}
