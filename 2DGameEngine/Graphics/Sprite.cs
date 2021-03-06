﻿using _2DGameEngine.Math;
using _2DGameEngine.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Dynamic;

namespace _2DGameEngine.Graphics
{
    public class Sprite
    {
        public Texture2D Texture { get; }
        public Point Size { get; set; }
        public Tileset SpriteSheet { get; }
        public SpriteEffects SpriteEffects { get; set; }
        public Rectangle SourceRectangle { get { if (SpriteSheet != null) { return new Rectangle(SpriteSheet.TileWidth * column, SpriteSheet.TileHeight * row, SpriteSheet.TileWidth, SpriteSheet.TileHeight); } else return new Rectangle(0, 0, Texture.Width, Texture.Height); } }
        private int _index;
        public int Index { get { return _index; } set {
                _index = value;
                row = (int)(_index / SpriteSheet.Columns);
                column = (int)(_index % SpriteSheet.Columns);
            } }
        public float Opacity { get; set; } = 1f;
        public SpriteAnimation Animation { get; set; }
        int row, column;
        public Sprite(string assetName)
        {
            Texture = RenderContext.Content.Load<Texture2D>(assetName);
            Size = new Point(Texture.Width, Texture.Height);
        }
        public Sprite(Texture2D texture2D)
        {
            Texture = texture2D;
            Size = new Point(Texture.Width, Texture.Height);
        }
        public Sprite(Tileset spritesheet, int index)
        {
            SpriteSheet = spritesheet;
            Index = index;
            row = (int)(index / SpriteSheet.Columns);
            column = (int)(index % SpriteSheet.Columns);
            Texture = SpriteSheet.Texture;
            Size = new Point(SpriteSheet.TileWidth, SpriteSheet.TileHeight);
        }
        public Sprite(Sprite sprite) //copy constructor
        {
            Texture = sprite.Texture;
            Size = sprite.Size;
            if(sprite.SpriteSheet != null)
            {
                SpriteSheet = sprite.SpriteSheet;
                Index = sprite.Index;
                row = (int)(Index / SpriteSheet.Columns);
                column = (int)(Index % SpriteSheet.Columns);
                Texture = SpriteSheet.Texture;
                Animation = sprite.Animation;
            }
        }
        public Sprite() { }
        public void Draw(Transform Transform, float layerDepth)
        {
            RenderContext.SpriteBatch.Draw(Texture, new Rectangle(Transform.Position, Transform.Size), SourceRectangle, Color.White * Opacity, Transform.Rotation, Transform.Origin, SpriteEffects, layerDepth);
        }
    }
}
