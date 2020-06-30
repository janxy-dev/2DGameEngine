using _2DGameEngine.Entities;
using Microsoft.Xna.Framework;
using System;

namespace _2DGameEngine.Particles
{
    public class ParticleComponent
    {
        Random rnd = new Random();
        public virtual void Initialize(ref Particle particle)
        {
            particle.Velocity = new Vector2(rnd.Next(-(int)particle.Velocity.X, (int)particle.Velocity.X), rnd.Next(-(int)particle.Velocity.Y, (int)particle.Velocity.Y));
        }
        public virtual void Update(ref Particle particle)
        {
            particle.Position += new Point((int)particle.Velocity.X, (int)particle.Velocity.Y);
            particle.Sprite.Opacity = (particle.Ticks / (float)particle.MaxTicks);
        }
    }
}
