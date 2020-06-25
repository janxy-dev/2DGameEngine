using _2DGameEngine.Entities;
using _2DGameEngine.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _2DGameEngine.Scenes
{
    public class Scene
    {
        public static Scene Instance { get; set; }
        public List<Entity> Entities { get; } = new List<Entity>();
        public TileMap TileMap { get; set; }
        public Point MousePosition { get 
            { 
                Vector2 pos = Vector2.Transform(new Vector2(Input.MousePosition.X, Input.MousePosition.Y), Matrix.Invert(Camera.TransformMatrix));
                return new Point((int)pos.X, (int)pos.Y);
            }
        }
        public Camera Camera { get; set; }
        public Scene()
        {
            Instance = this;
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
            RenderContext.SpriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Scene.Instance.Camera.TransformMatrix);
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Draw();
            }
            if (TileMap != null)
            {
                TileMap.Draw();
            }
            RenderContext.SpriteBatch.End();
        }
    }
}
