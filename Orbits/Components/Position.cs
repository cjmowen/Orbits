using Microsoft.Xna.Framework;

namespace Orbits.Components
{
    class Position: Component
    {
        public Vector2 Coordinates;
        public float Direction;

        public Position(float x = 0, float y = 0, float direction = 0)
        {
            Flag = ComponentFlag.Position;
            Coordinates = new Vector2(x, y);
            Direction = direction;
        }
    }
}
