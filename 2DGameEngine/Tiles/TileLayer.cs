using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Tiles
{
    public class TileLayer
    {
        public TileMap TileMap { get; }
        public Tile[,] Tiles { get; }
        public TileLayer(TileMap map)
        {
            map.TileLayers.Add(this);
            TileMap = map;
            Tiles = new Tile[TileMap.TileSize.X, TileMap.TileSize.Y];
        }
        public void Draw()
        {
            for (int x = 0; x < TileMap.Size.X; x++)
            {
                for (int y = 0; y < TileMap.Size.Y; y++)
                {
                    Tiles[x, y].Draw();
                }
            }
        }
        public void AddTile(Tile tile)
        {
            if (!TileMap.InBounds(tile.GridPosition.X, tile.GridPosition.Y))
            {
                throw new ArgumentException("Tile is out of map bounds!");
            }
            Tiles[tile.GridPosition.X, tile.GridPosition.Y] = tile;
        }
    }
}
