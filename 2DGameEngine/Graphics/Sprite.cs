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
        public Point Size { get; }
        public Sprite(string assetName)
        {
            Texture = RenderContext.Content.Load<Texture2D>(assetName);
            Size = new Point(Texture.Width, Texture.Height);
        }
        public Sprite(Texture2D texture2D)
        {
            Texture = texture2D;
        }
        public void Draw(Transform Transform)
        {
            RenderContext.SpriteBatch.Draw(Texture, new Rectangle(Transform.Position, Transform.Size), null, Color.White, Transform.Rotation, Transform.Origin, SpriteEffects.None, 0f);
        }
    }
}
