using _2DGameEngine.Entities;
using _2DGameEngine.Particles;
using _2DGameEngine.Tiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace _2DGameEngine.Scenes
{
    public enum EntityDepthSorting
    {
        Normal, SortByY
    }
    public class Layer
    {
        public Scene Scene { get; internal set; }
        public List<Entity> Entities { get; } = new List<Entity>();
        public EntityDepthSorting EntityDepthSorting { get; set; }
        public ParticleSystem ParticleSystem { get; }
        public int Index { get; set; }

        public Layer()
        {
            ParticleSystem = new ParticleSystem(this);
        }

        public void AddEntity(Entity entity)
        {
            entity.Layer = this;
            entity.Initialize();
            Entities.Add(entity);
        }
        public void RemoveEntity(Entity entity)
        {
            entity.Layer = null;
            Entities.Remove(entity);
        }
        public virtual void Draw(ref float layerDepth)
        {
            ParticleSystem.Draw(ref layerDepth, ParticleDepthSorting.UnderEntities);
            if(EntityDepthSorting == EntityDepthSorting.Normal)
            {
                for (int i = 0; i < Entities.Count; i++)
                {
                    layerDepth += 1 / 10000000f;
                    Entities[i].Draw(layerDepth);
                }
            }
            else if(EntityDepthSorting == EntityDepthSorting.SortByY)
            {
                float biggestDepth = 0f;
                for (int i = 0; i<Entities.Count; i++)
                {
                    if (Entities[i].Sprite == null) return;
                    float posY = Entities[i].Transform.Position.Y+Entities[i].Transform.Size.Y - Scene.Camera.Transform.Position.Y;
                    float depth = posY/ 10000000f;
                    if (biggestDepth < depth) biggestDepth = depth;
                    Entities[i].Draw(layerDepth + depth + i/(10000000f*Entities.Count));
                }
                ParticleSystem.Draw(ref layerDepth, ParticleDepthSorting.SortByY);
                layerDepth += biggestDepth;
            }
            ParticleSystem.Draw(ref layerDepth, ParticleDepthSorting.AboveEntities);
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
