using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.Components
{
    public class Size: Component
    {
        private float _size;
        public Vector2 Scale
        {
            get
            {
                return new Vector2(_size);
            }
        }

        public Size(float size)
        {
            Flag = ComponentFlag.Size;
            _size = size;
        }
    }
}
