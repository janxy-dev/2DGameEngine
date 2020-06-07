using _2DGameEngine.Graphics;
using _2DGameEngine.Math;
using _2DGameEngine.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Entities
{
    public abstract class Entity
    {
        public List<Component> Components { get; } = new List<Component>();
        public Sprite Sprite { get; set; }
        public Transform Transform = new Transform();
        public Entity(Scene scene)
        {
            scene.Entities.Add(this);
        }
        public void Update()
        {
            for(int i = 0; i<Components.Count; i++)
            {
                Components[i].Update();
            }
        }
        public void Draw()
        {
            if (Sprite != null) Sprite.Draw();
        }
    }
}
