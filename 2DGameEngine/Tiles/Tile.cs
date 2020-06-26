using _2DGameEngine.Math;
using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _2DGameEngine.Tiles
{
    public class Tile
    {
        public Rectangle SourceRectangle { get; }
        public int Row { get; protected set; }
        public int Column { get; protected set; }
        public int TileIndex { get; set; }
        public Tileset Tileset { get; private set; }
        public int Width { get { return Tileset.TileWidth; } }
        public int Height { get { return Tileset.TileHeight; } }
        public Point GridPosition { get; }
        public TileLayer TileLayer { get; }
        public Point Position { get { return new Point(GridPosition.X * TileLayer.TileSize.X, GridPosition.Y * TileLayer.TileSize.Y); } } //change later
        public Tile(TileLayer layer, Point gridPosition, Tileset tileset=null, int index=0)
        {
            TileLayer = layer;
            GridPosition = gridPosition;
            layer.AddTile(this);
            if (tileset == null) { return; }

            TileIndex = index;
            Tileset = tileset;

            Row = (int)(TileIndex / tileset.Columns);
            Column = (int)(TileIndex % tileset.Columns);
            SourceRectangle = new Rectangle(Tileset.TileWidth * Column, Tileset.TileHeight * Row, Tileset.TileWidth, Tileset.TileHeight);
        }
        public virtual void Draw()
        {
            if (Tileset != null)
            {
                RenderContext.SpriteBatch.Draw(Tileset.Texture, new Rectangle(Position.X, Position.Y, Width, Height), SourceRectangle, Color.White, 0f, new Vector2(0f, 0f), SpriteEffects.None, 0f);
            }

        }

    }
}
