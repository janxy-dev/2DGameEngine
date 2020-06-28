using _2DGameEngine.Entities;
using Microsoft.Xna.Framework;

namespace _2DGameEngine.Particles
{
    public class ParticleComponent
    {
        public virtual Particle Update(Particle Particle)
        {
            Particle.Position += new Point(Particle.Velocity.X, Particle.Velocity.Y);
            return Particle;
        }
    }
}
