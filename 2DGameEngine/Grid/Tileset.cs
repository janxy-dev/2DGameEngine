using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace _2DGameEngine.Grid
{
    public class Tileset
    {
        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }
        public string AssetName { get; private set; }
        public Texture2D Texture { get; private set; }
        public decimal Rows { get; private set; }
        public decimal Columns { get; private set; }
        public Tileset(string assetName, int tileWidth, int tileHeight)
        {
            this.TileWidth = tileWidth;
            this.TileHeight = tileHeight;
            this.AssetName = assetName;

            Texture = RenderContext.Content.Load<Texture2D>(AssetName);
            Columns = Texture.Width / TileWidth;
            Rows = Texture.Height / TileHeight;
            Debug.Assert((Rows * Columns % 1) <= 0);
        }
    }
}
