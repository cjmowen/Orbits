using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orbits.Components;
using System;
using System.Collections.Generic;

namespace Orbits.Entities
{
    public class EntityManager
    {
        public Dictionary<Guid, Entity> Entities;

        private Game _game;

        /// <summary>
        /// Keeps track of Entities and provides convenience methods for creating 
        /// new Entities.
        /// </summary>
        /// <param name="game"></param>
        public EntityManager(Game game)
        {
            _game = game;
            Entities = new Dictionary<Guid, Entity>();
        }

        /// <summary>
        /// Creates a planet.
        /// </summary>
        /// <param name="x">The planet's x-coordinate.</param>
        /// <param name="y">The planet's y-coordinate.</param>
        public Guid CreatePlanet(float x, float y, float mass)
        {
            // Planets remain stationary. They need a Graphics and Position
            // component. They also require a Gravity component and Mass component.
            Entity planet = new Entity();

            // The Content should cache files, so this shouldn't be too slow.
            Texture2D texture = _game.Content.Load<Texture2D>("circle");
            planet.Add(new Graphics(texture));
            planet.Add(new Position(x, y));
            planet.Add(new Mass(mass));
            planet.Add(new Gravity());
            planet.Add(new Size(10));

            AddEntity(planet);
            return planet.Guid;
        }

        public Guid CreateShip(float x, float y)
        {
            Entity ship = new Entity();

            Texture2D texture = _game.Content.Load<Texture2D>("littletriangle");
            ship.Add(new Graphics(texture));
            ship.Add(new Position(x, y, 0));
            ship.Add(new Input()
            {
                Left = Keys.A,
                Right = Keys.D,
                Forward = Keys.W,
                Backward = Keys.S
            });
            ship.Add(new Movement());
            ship.Add(new Mass(100));
            ship.Add(new Engine(100));

            AddEntity(ship);
            return ship.Guid;
        }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity.Guid, entity);
        }
    }
}
