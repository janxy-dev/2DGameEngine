using _2DGameEngine.Entities;
using _2DGameEngine.Tiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _2DGameEngine.Scenes
{
    public class Layer
    {
        public Scene Scene { get; internal set; }
        public Point Size { get; }
        private List<Entity> Entities { get; } = new List<Entity>();
        public Layer(int sizeX, int sizeY)
        {
            Size = new Point(sizeX, sizeY);
        }
        public bool InBounds(int x, int y)
        {
            if (x < Size.X && y < Size.Y && x >= 0 && y >= 0)
            {
                return true;
            }
            return false;
        }
        public void AddEntity(Entity entity)
        {
            entity.Layer = this;
            Entities.Add(entity);
        }
        public virtual void Draw()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Draw();
            }
        }
        public virtual void Update()
        {
            for(int i = 0; i<Entities.Count; i++)
            {
                Entities[i].Update();
            }
        }
    }
}
