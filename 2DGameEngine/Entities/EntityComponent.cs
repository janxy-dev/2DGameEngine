using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Entities
{
    public abstract class EntityComponent
    {
        public Entity Entity { get; set; }
        public virtual void Initialize()
        {

        }
        public virtual void Update() {}
    }
}
