using _2DGameEngine.Graphics;
using _2DGameEngine.Math;
using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Entities
{
    public class Entity
    {
        public Layer Layer { get; internal set; }
        public List<EntityComponent> Components { get; } = new List<EntityComponent>();
        public Sprite Sprite { get; set; }
        public Transform Transform = new Transform();
        public Entity(Sprite sprite)
        {
            Sprite = sprite;
            Transform.Size = sprite.Size;
        }
        public Entity(int width, int height)
        {
            Transform.Size = new Point(width, height);
        }
        public Entity() { }
        public EntityComponent GetComponent<T>()
        {
            return Components.Find(n => n.GetType() == typeof(T));
        }
        public virtual void Initialize()
        {
        }
        public void AddComponent(EntityComponent component)
        {
            component.Entity = this;
            component.Initialize();
            Components.Add(component);
        }
        public void Update()
        {
            for(int i = 0; i<Components.Count; i++)
            {
                Components[i].Update();
            }
        }
        public void Draw(float layerDepth)
        {
            if (Sprite != null)
            {
                Sprite.Draw(Transform, layerDepth);
            }
        }
    }
}
