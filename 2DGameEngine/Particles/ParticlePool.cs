using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Particles
{
    class ParticlePool
    {
        public Particle[] Array { get; }
        public int InactiveIndex { get; set; }
        public ParticleComponent ParticleComponent { get; set; }
        public ParticlePool(int count)
        {
            Array = new Particle[count];
            InactiveIndex = count-1;
        }
    }
}
