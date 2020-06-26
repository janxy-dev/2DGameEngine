using _2DGameEngine.Entities;
using _2DGameEngine.Tiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _2DGameEngine.Scenes
{
    public class Layer
    {
        public Scene Scene { get; }
        public Point Size { get; }
        public List<Entity> Entities { get; } = new List<Entity>();
        public Layer(Scene scene, int sizeX, int sizeY)
        {
            Size = new Point(sizeX, sizeY);
            scene.Layers.Add(this);
            Scene = scene;
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
