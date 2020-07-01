using _2DGameEngine.Entities;
using Microsoft.Xna.Framework;
using System;

namespace _2DGameEngine
{
    public class BoxColliderComponet : EntityComponent
    {
        Point size;
        Point offset;
        public override void Initialize()
        {
            size = Entity.Transform.Size;
            base.Initialize();
        }
        public Rectangle Bounds { get { return new Rectangle(Entity.Transform.Position+offset, size); } set { offset = value.Location-Entity.Transform.Position; size = value.Size; } }
        public bool Intersects(Rectangle bounds)
        {
            bool right = Bounds.X < bounds.X + bounds.Width;
            bool left = Bounds.X + Bounds.Width > bounds.X;
            bool up = Bounds.Y + Bounds.Height > bounds.Y;
            bool down = Bounds.Y < bounds.Y + bounds.Height;
            return right && left && up && down;
        }
    }
}
