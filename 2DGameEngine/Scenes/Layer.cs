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
        public ParticleSystem ParticleSystem { get; } = new ParticleSystem();

        public void AddEntity(Entity entity)
        {
            entity.Layer = this;
            Entities.Add(entity);
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
