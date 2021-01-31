using _2DGameEngine.Graphics;
using _2DGameEngine.Math;
using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _2DGameEngine.Particles
{
    public class ParticleSystem
    {
        public List<ParticlePool> ParticlePools { get; } = new List<ParticlePool>();
        public Layer Layer { get; }
        public ParticleSystem(Layer layer)
        {
            Layer = layer;
        }
        public void CreatePool(int count, Sprite sprite, ParticleComponent component, ParticleDepthSorting depthSorting)
        {
            var pool = new ParticlePool(count, component, depthSorting, this);
            ParticlePools.Add(pool);
            for (int i = 0; i<count; i++)
            {
                Particle particle = new Particle()
                {
                    Size = sprite.Size,
                    Texture = sprite.Texture,
                    Opacity = sprite.Opacity,
                    SourceRectangle = sprite.SourceRectangle
                };
                pool.Array[i] = particle;
            }
        }
        public void SpawnParticle(int index, Point position, List<object> objects, int ticks)
        {
            ref var particle = ref ParticlePools[index].Array[ParticlePools[index].InactiveIndex];
            particle.Position = position;
            particle.Ticks = ticks;
            particle.Objects = objects;
            ParticlePools[index].ParticleComponent.Initialize(ref particle);
            ParticlePools[index].InactiveIndex--;
        }
        public void Draw(ref float layerDepth, ParticleDepthSorting depthSorting)
        {
            for (int i = 0; i < ParticlePools.Count; i++)
            {
                if (ParticlePools[i].DepthSorting == depthSorting)
                {
                    ParticlePools[i].Draw(ref layerDepth);
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
