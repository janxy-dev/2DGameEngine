using _2DGameEngine.Entities;
using _2DGameEngine.Particles;
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
        public List<Layer> Layers { get; } = new List<Layer>();
        public Point MousePosition { get 
            { 
                Vector2 pos = Vector2.Transform(new Vector2(Input.MousePosition.X, Input.MousePosition.Y), Matrix.Invert(Camera.TransformMatrix));
                return new Point((int)pos.X, (int)pos.Y);
            }
        }
        public Camera Camera { get; set; }
        public static MgFrameRate FrameRate { get; set; }
        public Scene()
        {
            Instance = this;
            AddLayer(new Layer());
            Camera = new Camera();
            Layers[0].AddEntity(Camera);        }
        public void AddLayer(Layer layer)
        {
            layer.Scene = this;
            layer.Index = Layers.Count;
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
        RenderContext.SpriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp, null, null, null, Instance.Camera.TransformMatrix);
            float layerDepth = 0f;
            for (int i = 0; i<Layers.Count; i++)
            {
                Layers[i].Draw(ref layerDepth);
            }
        RenderContext.SpriteBatch.End();
        }
    }
}
