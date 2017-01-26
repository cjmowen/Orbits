using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.Components
{
    public class Movement: Component
    {
        public Vector2 Velocity;
        public Vector2 Acceleration;

        public Movement(float x = 0, float y = 0, float dx = 0, float dy = 0)
        {
            Flag = ComponentFlag.Movement;
            Velocity = new Vector2(x, y);
            Acceleration = new Vector2(dx, dy);
        }
    }
}
