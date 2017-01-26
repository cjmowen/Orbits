using Microsoft.Xna.Framework;
using Orbits.Entities;

namespace Orbits.Components
{
    public abstract class Component
    {
        public ComponentFlag Flag { get; protected set; }
    }
}
