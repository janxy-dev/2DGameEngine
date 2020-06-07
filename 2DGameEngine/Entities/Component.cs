using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Entities
{
    public abstract class Component
    {
        protected Entity Entity;
        public Component(Entity entity)
        {
            entity.Components.Add(this);
            Entity = entity;
        }
        public virtual void Update() {}
    }
}
