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
        private Tile[,] Tiles { get; }
        public Point TileSize { get; }
        public Point GridSize { get; }
        public TileLayer(int gridSizeX, int gridSizeY, int tileSizeX, int tileSizeY) : base(gridSizeX*tileSizeX, gridSizeY*tileSizeY)
        {
            Tiles = new Tile[gridSizeX, gridSizeY];
            TileSize = new Point(tileSizeX, tileSizeY);
            GridSize = new Point(gridSizeX, gridSizeY);
            for(int x = 0; x<gridSizeX; x++)
            {
                for(int y = 0; y<gridSizeY; y++)
                {
                    AddTile(new Tile(new Point(x, y)));
                }
            }
        }
        public new bool InBounds(int gridx, int gridy)
        {
            if (gridx < Size.X / TileSize.X && gridy < Size.Y / TileSize.Y && gridx >= 0 && gridy >= 0)
            {
                return true;
            }
            return false;
        }
        public Tile GetTile(int x, int y)
        {
            return Tiles[x, y];
        }
        public void AddTile(Tile tile)
        {
            tile.TileLayer = this;
            Tiles[tile.GridPosition.X, tile.GridPosition.Y] = tile;
            if(tile is AutoTile atile)
            {
                //Update autotiles!
                for (int x = atile.GridPosition.X - 1; x <= atile.GridPosition.X + 1; x++)
                {
                    for (int y = atile.GridPosition.Y - 1; y <= atile.GridPosition.Y + 1; y++)
                    {
                        if (InBounds(x, y) && GetTile(x, y) is AutoTile autoTile && autoTile.ID != "null")
                        {
                            autoTile.UpdateTexture();
                        }
                    }
                }
            }
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
