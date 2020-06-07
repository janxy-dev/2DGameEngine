using _2DGameEngine.Entities;
using _2DGameEngine.Grid;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _2DGameEngine.Scenes
{
    public class Scene
    {
        public static Scene current { get; set; } //remove later after making SceneManager
        public List<Entity> Entities { get; } = new List<Entity>();
        public TileMap TileMap { get; set; }
        public Camera Camera { get; set; }
        public Point MousePosition { get 
            { 
                Vector2 pos = Vector2.Transform(new Vector2(Input.MousePosition.X, Input.MousePosition.Y), Matrix.Invert(Camera.TransformMatrix));
                return new Point((int)pos.X, (int)pos.Y);
            }
        }
        public Scene()
        {
            current = this;
            Camera = new Camera(this);
        }
        public void Update()
        {
            for(int i = 0; i<Entities.Count; i++)
            {
                Entities[i].Update();
            }
        }
        public void Draw()
        {
            for(int i = 0; i<Entities.Count; i++)
            {
                Entities[i].Draw();
            }
            if(TileMap != null)
            {
                TileMap.Draw();
            }
        }
    }
}
