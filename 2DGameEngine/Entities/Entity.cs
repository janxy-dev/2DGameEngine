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
        private List<Component> Components { get; } = new List<Component>();
        public Sprite Sprite { get; private set; }
        public Transform Transform = new Transform();
        public void SetSprite(Sprite sprite)
        {
            Sprite = sprite;
            if (Transform.Size == new Point())
            {
                Transform.Size = sprite.Size;
            }
            else Sprite.Size = Transform.Size;
        }
        public Component[] GetComponents() { return Components.ToArray(); }
        public Component GetComponent<T>()
        {
            return Components.Find(n => n.GetType() == typeof(T));
        }
        public void AddComponent(Component component)
        {
            component.Entity = this;
            Components.Add(component);
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
                RenderContext.SpriteBatch.Draw(Sprite.Texture, new Rectangle(Transform.Position, Transform.Size), null, Color.White, Transform.Rotation, Transform.Origin, SpriteEffects.None, 0f);
        }
    }
}
