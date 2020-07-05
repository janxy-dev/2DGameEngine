using _2DGameEngine.Entities;
using _2DGameEngine.Particles;
using _2DGameEngine.Tiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace _2DGameEngine.Scenes
{
    public class Layer
    {
        public Scene Scene { get; internal set; }
        public List<Entity> Entities { get; } = new List<Entity>();
        public ParticleSystem ParticleSystem { get; }
        public int Index { get; set; }

        public Layer()
        {
            ParticleSystem = new ParticleSystem(this);
        }

        public void AddEntity(Entity entity)
        {
            entity.Layer = this;
            Entities.Add(entity);
        }
        public void RemoveEntity(Entity entity)
        {
            entity.Layer = null;
            Entities.Remove(entity);
        }
        public virtual void Draw(ref float layerDepth)
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                layerDepth += 1 / 10000000f;
                Entities[i].Draw(layerDepth);
            }
            ParticleSystem.Draw(ref layerDepth);
            
        }
        public virtual void Update()
        {
            for(int i = 0; i<Entities.Count; i++)
            {
                Entities[i].Update();
            }
            ParticleSystem.Update();
        }
    }
}
