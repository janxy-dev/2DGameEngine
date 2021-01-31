using _2DGameEngine.Graphics;
using _2DGameEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2DGameEngine.Particles
{
    public struct Particle
    {
        public List<object> Objects;
        public Rectangle SourceRectangle;
        public Texture2D Texture;
        public Point Size;
        public float Rotation;
        public float Opacity;

        public Point Position;
        public int Ticks;
        
    }
}
