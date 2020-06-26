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
        private List<Layer> Layers { get; } = new List<Layer>();
        public Point MousePosition { get 
            { 
                Vector2 pos = Vector2.Transform(new Vector2(Input.MousePosition.X, Input.MousePosition.Y), Matrix.Invert(Camera.TransformMatrix));
                return new Point((int)pos.X, (int)pos.Y);
            }
        }
        public Camera Camera { get; set; }
        public Scene(int sizeX, int sizeY)
        {
            Instance = this;
            Camera = new Camera();
            Layers.Add(new Layer(sizeX, sizeY));
            Layers[0].AddEntity(Camera);
        }
        public Layer GetLayer(int layerID)
        {
            return Layers[layerID];
        }
        public void AddLayer(Layer layer)
        {
            layer.Scene = this;
            Layers.Add(layer);
        }
        public void Update()
        {
            for(int i = 0; i<Layers.Count; i++)
            {
                Layers[i].Update();
            }
        }
        public void Draw()
        {
            RenderContext.SpriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Scene.Instance.Camera.TransformMatrix);
            for(int i = 0; i<Layers.Count; i++)
            {
                Layers[i].Draw();
            }
            RenderContext.SpriteBatch.End();
        }
    }
}
