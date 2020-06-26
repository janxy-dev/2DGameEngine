using _2DGameEngine.Tiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _2DGameEngine.Scenes
{
    public class TileLayer : Layer
    {
        public Tile[,] Tiles { get; }
        public Point TileSize { get; }
        public Point GridSize { get; }
        public TileLayer(Scene scene, int gridSizeX, int gridSizeY, int tileSizeX, int tileSizeY) : base(scene, gridSizeX*tileSizeX, gridSizeY*tileSizeY)
        {
            Tiles = new Tile[gridSizeX, gridSizeY];
            TileSize = new Point(tileSizeX, tileSizeY);
            GridSize = new Point(gridSizeX, gridSizeY);
        }
        public new bool InBounds(int gridx, int gridy)
        {
            if (gridx < Size.X / TileSize.X && gridy < Size.Y / TileSize.Y && gridx >= 0 && gridy >= 0)
            {
                return true;
            }
            return false;
        }
        public void AddTile(Tile tile)
        {
            Tiles[tile.GridPosition.X, tile.GridPosition.Y] = tile;
        }
        public override void Draw()
        {
            for(int x = 0; x<GridSize.X; x++)
            {
                for(int y = 0; y<GridSize.Y; y++)
                {
                    Tiles[x, y].Draw();
                }
            }
            base.Draw();
        }
    }
}
