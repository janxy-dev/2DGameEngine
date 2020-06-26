using _2DGameEngine.Graphics;
using _2DGameEngine.Math;
using _2DGameEngine.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Entities
{
    public class Entity
    {
        public Layer Layer { get; }
        public List<Component> Components { get; } = new List<Component>();
        public Sprite Sprite { get; set; }
        public Transform Transform = new Transform();
        public Entity(Layer layer)
        {
            Layer = layer;
            layer.Entities.Add(this);
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
            if (Sprite != null)
                Sprite.Draw();
        }
    }
}
