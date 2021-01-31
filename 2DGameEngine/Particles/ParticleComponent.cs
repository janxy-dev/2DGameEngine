using Microsoft.Xna.Framework;
using System;

namespace _2DGameEngine.Particles
{
    public class ParticleComponent
    {
        public virtual void Initialize(ref Particle particle)
        {
        }
        public virtual void Update(ref Particle particle)
        {
            particle.Position += new Point(5, 5);
        }
    }
}
