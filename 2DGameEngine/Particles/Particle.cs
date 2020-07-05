using _2DGameEngine.Graphics;
using _2DGameEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DGameEngine.Particles
{
    public struct Particle
    {
        public int ID;
        public bool IsActive;
        public Point Position;
        public float Rotation;
        public Vector2 Velocity;
        public int MaxTicks;
        public int Ticks;

        public Point Size;
        public Texture2D Texture;
        public float Opacity;
        public Rectangle SourceRectangle;
    }
}
