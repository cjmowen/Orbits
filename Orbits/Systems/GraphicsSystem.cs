using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Orbits.Components;
using Orbits.Entities;
using System;
using System.Collections.Generic;

namespace Orbits.Systems
{
    public class GraphicsSystem
    {
        private ComponentFlag _key;

        public Camera Camera;
        public GraphicsDevice GraphicsDevice;
        
        public GraphicsSystem(GraphicsDevice graphicsDevice)
        {
            _key = ComponentFlag.Graphics | ComponentFlag.Position;
            Camera = new Camera();
            GraphicsDevice = graphicsDevice;
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<Guid, Entity> entities)
        {
            Position position;
            Graphics graphics;
            Vector2 scale;

            spriteBatch.Begin(
                sortMode: SpriteSortMode.BackToFront,
                blendState: BlendState.AlphaBlend,
                transformMatrix: Camera.GetTransformation(GraphicsDevice));

            foreach (var entity in entities.Values)
            {
                if (entity.Has(_key))
                {
                    position = (Position) entity.Get(ComponentFlag.Position);
                    graphics = (Graphics) entity.Get(ComponentFlag.Graphics);

                    // If the Entity has a Size, use that to scale the texture.
                    if (entity.Has(ComponentFlag.Size))
                    {
                        scale = ((Size) entity.Get(ComponentFlag.Size)).Scale;
                    }
                    else
                    {
                        scale = Vector2.One;
                    }

                    spriteBatch.Draw(
                        texture: graphics.Texture,
                        position: position.Coordinates,
                        origin: new Vector2(graphics.Texture.Width * 0.5f, graphics.Texture.Height * 0.5f),
                        rotation: position.Direction,
                        scale: scale,
                        color: Color.White);
                }
            }

            spriteBatch.End();
        }
    }

}
