using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Entities
{
    public class Component
    {
        public Entity Entity { get; set; }
        public virtual void Update() {}
    }
}
