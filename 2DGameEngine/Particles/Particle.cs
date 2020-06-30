using _2DGameEngine.Entities;
using _2DGameEngine.Graphics;
using _2DGameEngine.Math;
using Microsoft.Xna.Framework;
using System;

namespace _2DGameEngine.Particles
{
    public struct Particle
    {
        public int ID;
        public int PoolIndex;
        public bool IsActive;
        public Point Position;
        public Point Size;
        public Vector2 Velocity;
        public int MaxTicks;
        public int Ticks;
        public Sprite Sprite;
    }
}
