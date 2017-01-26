using Microsoft.Xna.Framework.Input;
using Orbits.Entities;

namespace Orbits.Components
{
    class Input: Component
    {
        public Keys Left;
        public Keys Right;
        public Keys Forward;
        public Keys Backward;

        public Input()
        {
            Flag = ComponentFlag.Input;
        }
    }
}
