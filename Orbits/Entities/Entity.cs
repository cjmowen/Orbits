using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orbits.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Orbits.Entities
{
    public class Entity
    {
        public Guid Guid { get; }
        private ComponentFlag _componentKey = ComponentFlag.None;
        private Dictionary<ComponentFlag, Component> _components;

        public Entity()
        {
            Guid = Guid.NewGuid();
            _components = new Dictionary<ComponentFlag, Component>();
        }

        public bool Has(ComponentFlag flag)
        {
            // Bitwise operation to determine if the Component with the specified flag is present.
            return (_componentKey & flag) == flag;
        }

        public void Add(Component component)
        {
            // Add the Component to the list, and set the flag for that Component type.
            // TODO: Check if entity already has component before adding another.
            _components.Add(component.Flag, component);
            _componentKey = _componentKey | component.Flag;
        }

        public void Remove(ComponentFlag flag)
        {
            // TODO: Check that entity has component before removing it.
            _components.Remove(flag);
        }

        public Component Get(ComponentFlag flag)
        {
            // TODO: Check that entity has component before returning it.
            return _components[flag];
        }
    }
}
