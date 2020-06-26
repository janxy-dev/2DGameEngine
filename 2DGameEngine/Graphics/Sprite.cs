using _2DGameEngine.Entities;
using _2DGameEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Graphics
{
    public class Sprite
    {
        public Texture2D Texture { get; }
        public Entity Entity { get; }
        public Sprite(Entity entity, string assetName)
        {
            Entity = entity;
            Texture = RenderContext.Content.Load<Texture2D>(assetName);
            //If size is 0, set it to Texture2D size
            if(entity.Transform.Size == new Point())
            {
                entity.Transform.Size = new Point(Texture.Width, Texture.Height);
            }
        }
        public Sprite(Entity entity, Texture2D texture)
        {
            Entity = entity;
            Texture = texture;
            entity.Sprite = this;
            if (entity.Transform.Size == new Point())
            {
                Entity.Transform.Size = new Point(Texture.Width, Texture.Height);
            }
        }
        public void Draw()
        {
            RenderContext.SpriteBatch.Draw(Texture, new Rectangle(Entity.Transform.Position, Entity.Transform.Size), null, Color.White, Entity.Transform.Rotation, Entity.Transform.Origin, SpriteEffects.None, 0f);
        }
    }
}
