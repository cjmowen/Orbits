using Microsoft.Xna.Framework;
using Orbits.Components;
using Orbits.Entities;
using Orbits.Utilities;
using System;
using System.Collections.Generic;

namespace Orbits.Systems
{
    public class PhysicsSystem
    {
        private ComponentFlag _forcesKey;
        private ComponentFlag _movementKey;
        private ComponentFlag _gravityKey;

        public PhysicsSystem()
        {
            _movementKey = ComponentFlag.Position | ComponentFlag.Movement;
            _forcesKey = _movementKey | ComponentFlag.Mass;
            _gravityKey = ComponentFlag.Position | ComponentFlag.Gravity | ComponentFlag.Mass;
        }

        public void Update(GameTime gameTime, Dictionary<Guid, Entity> entities)
        {
            ApplyForces(entities);
            Move(gameTime, entities);
        }

        private void Move(GameTime gameTime, Dictionary<Guid, Entity> entities)
        {
            foreach (var entity in entities.Values)
            {
                if (entity.Has(_movementKey))
                {

                    Movement movement = (Movement) entity.Get(ComponentFlag.Movement);
                    Position position = (Position) entity.Get(ComponentFlag.Position);
                    movement.Velocity += movement.Acceleration;


                    // Move however many meters per second.
                    position.Coordinates += movement.Velocity * (float) gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
        }

        private void ApplyForces(Dictionary<Guid, Entity> entities)
        {
            Vector2 totalForce;
            Movement movement;
            Mass mass;

            foreach (var entity in entities.Values)
            {
                // Only apply forces to Entities that are capable of forces.
                if (entity.Has(_forcesKey))
                {
                    totalForce = new Vector2(0, 0);
                    movement = (Movement) entity.Get(ComponentFlag.Movement);
                    mass = (Mass) entity.Get(ComponentFlag.Mass);

                    // Calculate gravitational pull from nearby bodies.
                    foreach (var otherEntity in entities.Values)
                    {
                        if (entity.Guid.Equals(otherEntity.Guid)) continue;

                        totalForce += GetGravity(entity, otherEntity);
                    }

                    // Apply engine force.
                    if (entity.Has(ComponentFlag.Engine | _movementKey))
                    {
                        Position position = (Position) entity.Get(ComponentFlag.Position);
                        Engine engine = (Engine) entity.Get(ComponentFlag.Engine);

                        // Using trig, we can determine the thrust vector from the thrust of the engine (hypotenuse)
                        // and the ship's direction (theta).
                        // > x = thrust * cos(direction)
                        // > y = thrust * sin(direction)
                        Vector2 thrust = new Vector2(engine.Thrust * FMath.Cos(position.Direction), engine.Thrust * FMath.Sin(position.Direction));
                        totalForce += thrust;
                    }

                    // F = ma => a = F/m
                    movement.Acceleration = totalForce / mass.Amount;
                }
            }
        }

        private Vector2 GetGravity(Entity thing, Entity source)
        {

            Vector2 force = Vector2.Zero;

            // If source has Gravity, and the thing in queistion doesn't, calculate the gravitational pull on thing.
            if (source.Has(_gravityKey) && !thing.Has(_gravityKey))
            {
                // G = M/r^2
                //   G: Force of gravity
                //   M: Mass of planet
                //   r: distance from planet center of mass to object center of mass

                Mass m1 = (Mass) source.Get(ComponentFlag.Mass);
                Position p1 = (Position) source.Get(ComponentFlag.Position);
                Position p2 = (Position) thing.Get(ComponentFlag.Position);
                float distance = Vector2.Distance(p1.Coordinates, p2.Coordinates);

                if (distance > 0)
                {
                    // Direction is the unit vector from A to B (VectorA - VectorB).
                    force = p1.Coordinates - p2.Coordinates;
                    force.Normalize();

                    // Unit vector multiplied by the magnitude of the force gives us the force vector for gravity.
                    force *= m1.Amount / (distance * distance);
                }
            }
            return force;
        }
    }
}
