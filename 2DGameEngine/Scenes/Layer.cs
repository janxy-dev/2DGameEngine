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
        public enum DepthSortingMethod
        {
            Normal, SortByHeight
        }
        public Scene Scene { get; internal set; }
        public List<Entity> Entities { get; } = new List<Entity>();
        public DepthSortingMethod EntityDepthSorting;
        public ParticleSystem ParticleSystem { get; }
        public int Index { get; set; }

        public Layer()
        {
            ParticleSystem = new ParticleSystem(this);
            EntityDepthSorting = DepthSortingMethod.SortByHeight;
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
            if(EntityDepthSorting == DepthSortingMethod.Normal)
            {
                for (int i = 0; i < Entities.Count; i++)
                {
                    layerDepth += 1 / 10000000f;
                    Entities[i].Draw(layerDepth);
                }
            }
            else if(EntityDepthSorting == DepthSortingMethod.SortByHeight)
            {
                float lowestHeight = 0f;
                for (int i = 0; i<Entities.Count; i++)
                {
                    if (Entities[i].Sprite == null) return;
                    Vector2 a = Vector2.Transform(new Vector2(Entities[i].Transform.Position.X, Entities[i].Transform.Position.Y+Entities[i].Transform.Size.Y), Scene.Camera.TransformMatrix);
                    Console.WriteLine(a.Y);
                    float height = a.Y/ 10000000f;
                    if(lowestHeight < height) lowestHeight = height;
                    Entities[i].Draw(layerDepth + height);
                }
                layerDepth += lowestHeight;

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
