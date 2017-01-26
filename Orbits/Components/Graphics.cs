using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orbits.Entities;

namespace Orbits.Components
{
    public class Graphics: Component
    {
        public Texture2D Texture;

        public Graphics(Texture2D texture)
        {
            Flag = ComponentFlag.Graphics;
            Texture = texture;
        }
    }
}
