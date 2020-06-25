using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace _2DGameEngine.Tiles
{
    public class Tileset
    {
        public int TileWidth { get; }
        public int TileHeight { get; }
        public int TileCount { get; }
        public string AssetName { get; }
        public Texture2D Texture { get; }
        public decimal Rows { get; }
        public decimal Columns { get; }
        public Tileset(string assetName, int tileWidth, int tileHeight)
        {
            this.TileWidth = tileWidth;
            this.TileHeight = tileHeight;
            this.AssetName = assetName;

            Texture = RenderContext.Content.Load<Texture2D>(AssetName);
            Columns = Texture.Width / TileWidth;
            Rows = Texture.Height / TileHeight;
            Debug.Assert((Rows * Columns % 1) <= 0);
            TileCount = (int)(Columns * Rows);
        }
    }
}
