using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orbits.Components;
using Orbits.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.Systems
{
    // http://www.david-amador.com/2009/10/xna-camera-2d-with-zoom-and-rotation/
    public class Camera
    {
        protected float _zoom;
        protected float _rotation;
        protected Matrix _transform;
        protected Vector2 _position;

        public Entity Follow;

        public Vector2 Position
        {
            get
            {
                if (Follow == null || !Follow.Has(ComponentFlag.Position))
                {
                    // If the camera is not following an entity, or that entity has no position,
                    // use the position value.
                    return _position;
                }
                else
                {
                    // If following an entity with a position, use that entity's position.
                    return ((Position) Follow.Get(ComponentFlag.Position)).Coordinates;
                }
            }
            set
            {
                _position = value;
            }
        }

        public float Zoom
        {
            get
            {
                return _zoom;
            }

            set
            {
                _zoom = MathHelper.Clamp(value, 0.1f, 1f);
            }
        }

        public Camera(Entity follow = null)
        {
            _zoom = 0.25f;
            _rotation = 0;
            _position = Vector2.Zero;
            Follow = follow;
        }

        public Matrix GetTransformation(GraphicsDevice graphicsDevice)
        {
            _transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                Matrix.CreateRotationZ(_rotation) *
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f, graphicsDevice.Viewport.Height * 0.5f, 0));

            return _transform;
        }
    }
}
