using Microsoft.Xna.Framework.Input;
using Orbits.Components;
using Orbits.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.Systems
{
    class InputSystem
    {
        private ComponentFlag inputKey;

        public InputSystem()
        {
            inputKey = ComponentFlag.Input;
        }

        public void GetInput(Dictionary<Guid, Entity> entities)
        {
            KeyboardState kb = Keyboard.GetState();
            Input input;

            foreach (var entity in entities.Values)
            {
                if (entity.Has(inputKey)) {
                    input = (Input) entity.Get(ComponentFlag.Input);

                    // Flying.
                    if (entity.Has(ComponentFlag.Engine))
                    {
                        Engine engine = (Engine) entity.Get(ComponentFlag.Engine);

                        if (kb.IsKeyDown(input.Forward))
                        {
                            engine.Throttle = 1;
                        }
                        else
                        {
                            engine.Throttle = 0;
                        }
                    }

                    // Steering.
                    if (entity.Has(ComponentFlag.Position))
                    {
                        Position position = (Position) entity.Get(ComponentFlag.Position);

                        if (kb.IsKeyDown(input.Left)) position.Direction -= .05f;
                        if (kb.IsKeyDown(input.Right)) position.Direction += .05f;
                    }
                }
            }
        }
    }
}
