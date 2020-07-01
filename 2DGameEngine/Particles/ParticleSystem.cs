using _2DGameEngine.Graphics;
using _2DGameEngine.Math;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace _2DGameEngine.Particles
{
    public class ParticleSystem
    {
        private List<ParticlePool> ParticlePools = new List<ParticlePool>();
        private int PoolIndex = 0;
        public void CreatePool(Sprite sprite, ParticleComponent component, int count)
        {
            var pool = new ParticlePool(count);
            pool.ParticleComponent = component;
            ParticlePools.Add(pool);
            for (int i = 0; i<count; i++)
            {
                Particle particle = new Particle()
                {
                    PoolIndex = PoolIndex,
                    Sprite = new Sprite(sprite),
                    Size = sprite.Size,
                };
                ParticlePools[PoolIndex].Array[i] = particle;
            }
        }
        public void SpawnParticles(int index, Point position, Vector2 velocity, int count, int ticks)
        {
            for(int i = ParticlePools[index].InactiveIndex; i>ParticlePools[index].InactiveIndex-count; i--)
            {
                ParticlePools[index].Array[i].IsActive = true;
                ref var particle = ref ParticlePools[index].Array[i];
                particle.Position = position;
                particle.Velocity = velocity;
                particle.MaxTicks = ticks;
                particle.Ticks = ticks;
                ParticlePools[index].ParticleComponent.Initialize(ref particle);
            }
            ParticlePools[index].InactiveIndex -= count;
        }
        public void Draw()
        {
            for(int n = 0; n<ParticlePools.Count; n++)
            {
                for (int i = ParticlePools[n].Array.Length-1; i > ParticlePools[n].InactiveIndex; i--)
                {
                    ParticlePools[n].Array[i].Sprite.Draw(new Transform(ParticlePools[n].Array[i].Position, ParticlePools[n].Array[i].Size));
                }
            }
        }
        public void Update()
        {
            for (int n = 0; n < ParticlePools.Count; n++)
            {
                for (int i = ParticlePools[n].InactiveIndex + 1; i < ParticlePools[n].Array.Length; i++)
                {
                    var pool = ParticlePools[n].Array;
                    if (pool[i].Ticks < 1)
                    {
                        ParticlePools[n].InactiveIndex++;
                        pool[i].IsActive = false;
                        Particle p = pool[i];
                        pool[i] = pool[ParticlePools[n].InactiveIndex];
                        pool[ParticlePools[n].InactiveIndex] = p;
                        continue;
                    }
                    ParticlePools[n].ParticleComponent.Update(ref pool[i]);
                    pool[i].Ticks--;
                }
                //Console.WriteLine(ParticlePools[n].Array.Length - (ParticlePools[n].InactiveIndex + 1));
            }
        }
    }
}
