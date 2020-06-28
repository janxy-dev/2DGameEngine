using _2DGameEngine.Graphics;
using _2DGameEngine.Math;
using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _2DGameEngine.Particles
{
    public class ParticleSystem
    {
        private static Dictionary<int, Queue<Particle>> particles = new Dictionary<int, Queue<Particle>>();
        List<Particle> activeParticles = new List<Particle>();
        private static Dictionary<int, ParticleComponent> particleComponents = new Dictionary<int, ParticleComponent>();
        public static void AddParticles(Sprite sprite, ParticleComponent component, int count, int ID)
        {
            particles[ID] = new Queue<Particle>(count);
            particleComponents[ID] = component;
            for (int i = 0; i<count; i++)
            {
                Particle particle = new Particle()
                {
                    Sprite = sprite,
                    Size = sprite.Size,
                };
                particles[ID].Enqueue(particle);
            }
        }
        Random rnd = new Random();
        public void SpawnParticles(int id, Point position, int count, int speed, int ticks)
        {
            for(int i = count-1; i>=0; i--)
            {
                var particle = particles[id].Dequeue();
                particle.Position = position;
                particle.Velocity = new Point(rnd.Next(-speed, speed+1), rnd.Next(-speed, speed+1));
                particle.ID = id;
                particle.Ticks = ticks;
                activeParticles.Add(particle);
            }
        }
        public void Draw()
        {
            for(int i = 0; i<activeParticles.Count; i++)
            {
                activeParticles[i].Sprite.Draw(new Transform(activeParticles[i].Position, activeParticles[i].Size));
            }
        }
        public void Update()
        {
            for (int i = activeParticles.Count-1; i >=0 ; i--)
            {
                Particle particle = activeParticles[i];
                if (particle.Ticks < 1)
                {
                    particles[particle.ID].Enqueue(particle);
                    activeParticles.RemoveAt(i);
                    continue;
                }
                particle = particleComponents[particle.ID].Update(particle);

                particle.Ticks--;
                activeParticles[i] = particle;
            }
        }
    }
}
