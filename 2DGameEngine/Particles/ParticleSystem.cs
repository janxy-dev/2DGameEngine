using _2DGameEngine.Graphics;
using _2DGameEngine.Math;
using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2DGameEngine.Particles
{
    public class ParticleSystem
    {
        private List<ParticlePool> ParticlePools = new List<ParticlePool>(10);
        public Layer Layer { get; }
        public ParticleSystem(Layer layer)
        {
            Layer = layer;
        }
        public void CreatePool(Sprite sprite, ParticleComponent component, int count)
        {
            var pool = new ParticlePool(count);
            pool.ParticleComponent = component;
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
                ParticlePools[ParticlePools.Count-1].Array[i] = particle;
            }
        }
        public void SpawnParticles(int index, Point position, Vector2 velocity, int count, int ticks)
        {
            for(int i = ParticlePools[index].InactiveIndex; i>ParticlePools[index].InactiveIndex-count; i--)
            {
                ref var particle = ref ParticlePools[index].Array[i];
                particle.IsActive = true;
                particle.Position = position;
                particle.Velocity = velocity;
                particle.MaxTicks = ticks;
                particle.Ticks = ticks;
                ParticlePools[index].ParticleComponent.Initialize(ref particle);
            }
            ParticlePools[index].InactiveIndex -= count;
        }
        public void Draw(ref float layerDepth)
        {
            for (int n = 0; n<ParticlePools.Count; n++)
            {
                float biggestTicks = 0f;
                for (int i = ParticlePools[n].Array.Length-1; i > ParticlePools[n].InactiveIndex; i--)
                {
                    var particle = ParticlePools[n].Array[i];
                    float depth = layerDepth + (particle.Ticks+1) / 10000000f;
                    RenderContext.SpriteBatch.Draw(particle.Texture, new Rectangle(particle.Position, particle.Size), particle.SourceRectangle, Color.White*particle.Opacity, particle.Rotation, new Vector2(), SpriteEffects.None, depth);
                    if (particle.Ticks+1 > biggestTicks) biggestTicks = particle.Ticks+1;
                    if(i== ParticlePools[n].InactiveIndex+1)
                        layerDepth += biggestTicks / 10000000f;
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
