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
        public Point Size { get; set; }
        public Sprite(string assetName)
        {
            Texture = RenderContext.Content.Load<Texture2D>(assetName);
            Size = new Point(Texture.Width, Texture.Height);
        }
        public Sprite(Texture2D texture)
        {
            Texture = texture;
            Size = new Point(Texture.Width, Texture.Height);
        }
    }
}
