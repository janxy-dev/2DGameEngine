using _2DGameEngine.Entities;
using _2DGameEngine.Particles;
using _2DGameEngine.Tiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _2DGameEngine.Scenes
{
    public class Layer
    {
        public Scene Scene { get; internal set; }
        private List<Entity> Entities { get; } = new List<Entity>();
        public ParticleSystem ParticleSystem { get; }
        static float depthCounter { get; set; } = 0f;
        public static int MaxLayers { get; } = 1000;
        public float Depth { get; }
        public float EntityDepth { get { return Depth + 1f / (MaxLayers*10); } }
        public float LastEntityDepth { get { return EntityDepth + (Entities.Count - 1) / (MaxLayers * 10f * Entities.Count); } }
        public Layer()
        {
            ParticleSystem = new ParticleSystem(this);
            Depth = depthCounter;
            depthCounter += 1f / MaxLayers;
        }

        public void AddEntity(Entity entity)
        {
            entity.Layer = this;
            Entities.Add(entity);
            entity.LayerDepth = LastEntityDepth;
        }
        public Entity[] GetEntities()
        {
            return Entities.ToArray();
        }
        public void RemoveEntity(Entity entity)
        {
            entity.Layer = null;
            Entities.Remove(entity);
        }
        public virtual void Draw()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Draw();
            }
            ParticleSystem.Draw();
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
