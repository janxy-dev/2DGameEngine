using _2DGameEngine.Entities;
using _2DGameEngine.Math;
using Microsoft.Xna.Framework;
using System;

namespace _2DGameEngine
{
    public class BoxCollider : EntityComponent
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
        public bool Intersects(Circle circle)
        {
            float closestX = MathHelper.Clamp(circle.Center.X, Bounds.Left, Bounds.Right);
            float closestY = MathHelper.Clamp(circle.Center.Y, Bounds.Top, Bounds.Bottom);

            Vector2 closestPoint = new Vector2(closestX, closestY);
            Vector2 center = new Vector2(circle.Center.X, circle.Center.Y);

            float distance = Vector2.Distance(closestPoint, center);
            Console.WriteLine(center);
            return distance < circle.Radius;
        }
    }
}
