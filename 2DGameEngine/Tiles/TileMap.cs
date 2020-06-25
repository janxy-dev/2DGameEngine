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
        private Tile[,] _Tiles;
        public TileMap(Scene scene, int sizeX, int sizeY, int tileSizeX, int tileSizeY)
        {
            _Tiles = new Tile[sizeX, sizeY];
            TileSize = new Point(tileSizeX, tileSizeY);
            Size = new Point(sizeX, sizeY);
            scene.TileMap = this;
            Scene = scene;

            for(int x = 0; x<sizeX; x++)
            {
                for(int y = 0; y<sizeY; y++)
                {
                    AddTile(new Tile(this, new Point(x,y)));
                }
            }
        }
        public Tile[,] GetTiles() { return _Tiles; }
        public bool InBounds(int gridx, int gridy)
        {
            if (gridx < Size.X && gridy < Size.Y && gridx >= 0 && gridy >= 0)
            {
                return true;
            }
            return false;
        }
        public void AddTile(Tile tile)
        {
            if(!InBounds(tile.GridPosition.X, tile.GridPosition.Y))
            {
                throw new ArgumentException("Tile is out of map bounds!");
            }
            _Tiles[tile.GridPosition.X, tile.GridPosition.Y] = tile;
        }
        public void Draw()
        {
            for(int x = 0; x<Size.X; x++)
            {
                for(int y = 0; y<Size.Y; y++)
                {
                    _Tiles[x, y].Draw();
                }
            }
        }
    }
}
