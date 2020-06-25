using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Tiles
{
    public class TileMap
    {
        public Point TileSize { get; }
        public Point Size { get; }
        public Scene Scene { get; }
        public Point MousePosition { get { return Scene.MousePosition/TileSize; } }
        public List<TileLayer> TileLayers { get; } = new List<TileLayer>();
        public TileMap(Scene scene, int sizeX, int sizeY, int tileSizeX, int tileSizeY)
        {
            TileSize = new Point(tileSizeX, tileSizeY);
            Size = new Point(sizeX, sizeY);
            scene.TileMap = this;
            Scene = scene;
        }
        public bool InBounds(int gridx, int gridy)
        {
            if (gridx < Size.X && gridy < Size.Y && gridx >= 0 && gridy >= 0)
            {
                return true;
            }
            return false;
        }
        public void Draw()
        {
            for (int i = 0; i<TileLayers.Count; i++)
            {
                TileLayers[i].Draw();
            }
        }
    }
}
