using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Entities
{
    public class Component
    {
        public Entity Entity { get; set; }
        public Component(Entity entity)
        {
            if (entity == null) return;
            Entity = entity;
        }
        public Component() { }
        public virtual void Update() {}
    }
}
