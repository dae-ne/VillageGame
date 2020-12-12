using SFML.Graphics;
using System.Collections.Generic;

namespace VillageGame.App
{
    class TextureManager
    {
        private Dictionary<string, Texture> _textures;

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


        public Texture GetTexture(string name) => _textures[name];
    }
}
