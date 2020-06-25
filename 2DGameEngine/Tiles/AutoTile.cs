using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DGameEngine.Tiles
{
    public class AutoTile : Tile
    {
        struct AdjacentValues
        {
            public int TL;
            public int TR;
            public int BL;
            public int BR;
        }
        struct ChunkList
        {
            public Rectangle[] TL { get; set; }
            public Rectangle[] TR { get; set; }
            public Rectangle[] BL { get; set; }
            public Rectangle[] BR { get; set; }
            public ChunkList(int a)
            {
                TL = new Rectangle[a];
                TR = new Rectangle[a];
                BL = new Rectangle[a];
                BR = new Rectangle[a];
            }
        }
        ChunkList Chunks;
        AdjacentValues Value { get; set; }
        public string ID { get { if (Tileset != null) { return Tileset.AssetName + TileIndex; } else { return "null"; } } }
        public AutoTile(TileMap tilemap, Point gridPosition, Tileset tileset=null, int index = 0) : base(tilemap, gridPosition, tileset, index)
        {
            //Update autotiles!
            for (int x = gridPosition.X - 1; x <= gridPosition.X + 1; x++)
            {
                for (int y = gridPosition.Y - 1; y <= gridPosition.Y + 1; y++)
                {
                    if (tilemap.InBounds(x, y) && tilemap.GetTiles()[x, y] is AutoTile autoTile && autoTile.ID != "null")
                    {
                        autoTile.UpdateTexture();
                    }
                }
            }
            if (tileset == null) { return; }
            TileIndex = index;
            Chunks = new ChunkList(5);
            Row = (int)(TileIndex / (tileset.Columns / 2));
            Column = (int)(TileIndex % (tileset.Columns / 2));
            AddChunks(3, 3, 3, 3, CutTile(Column * Width * 2 + Width, Row * 3 * Height));
            AddChunks(0, 2, 1, 4, CutTile(Column * Width * 2, Row * 3 * Height + Height));
            AddChunks(1, 0, 4, 2, CutTile(Column * Width * 2 + Width, Row * 3 * Height + Height));
            AddChunks(2, 4, 0, 1, CutTile(Column * Width * 2, Row * 3 * Height + Height * 2));
            AddChunks(4, 1, 2, 0, CutTile(Column * Width * 2 + Width, Row * 3 * Height + Height * 2));   
        }
        public bool HasNeighbour(int x, int y)
        {
            return TileMap.InBounds(x, y) && TileMap.GetTiles()[x, y] != null && TileMap.GetTiles()[x, y] is AutoTile tile && tile.ID == ID;
        }
        void AddChunks(int first, int second, int third, int fourth, Rectangle[] chunks)
        {
            this.Chunks.TL[first] = chunks[0];
            this.Chunks.TR[second] = chunks[1];
            this.Chunks.BL[third] = chunks[2];
            this.Chunks.BR[fourth] = chunks[3];
        }
        Rectangle[] CutTile(int x, int y)
        {
            int hw = Width / 2;
            int hh = Height / 2;
            Rectangle[] chunk = new Rectangle[4];
            chunk[0] = new Rectangle(x, y, hw, hh); //TL
            chunk[1] = new Rectangle(x + hw, y, hw, hh); //TR
            chunk[2] = new Rectangle(x, y + hh, hw, hh); //BL
            chunk[3] = new Rectangle(x + hw, y + hh, hw, hh); //BR
            return chunk;
        }
        public void UpdateTexture()
        {
            Point pos = GridPosition;
            var val = new AdjacentValues();
            int w = 1; int h = 1;
            if (HasNeighbour(pos.X, pos.Y - h)) { val.TL += 2; val.TR += 1; } //top
            if (HasNeighbour(pos.X, pos.Y + h)) { val.BL += 1; val.BR += 2; } //bottom
            if (HasNeighbour(pos.X - w, pos.Y)) { val.TL += 1; val.BL += 2; } //left
            if (HasNeighbour(pos.X + w, pos.Y)) { val.TR += 2; val.BR += 1; } //right
            if (HasNeighbour(pos.X - w, pos.Y - h) && val.TL == 3) { val.TL = 4; }
            if (HasNeighbour(pos.X + w, pos.Y - h) && val.TR == 3) { val.TR = 4; }
            if (HasNeighbour(pos.X - w, pos.Y + h) && val.BL == 3) { val.BL = 4; }
            if (HasNeighbour(pos.X + w, pos.Y + h) && val.BR == 3) { val.BR = 4; }
            Value = val;
        }
        Point fixoff = new Point();
        public override void Draw()
        {
            if (Tileset == null) return;
            fixoff.X = (Width / 2 - TileMap.TileSize.X / 2) / -2;
            fixoff.Y = (Height / 2 - TileMap.TileSize.Y / 2) / -2;
            RenderContext.SpriteBatch.Draw(Tileset.Texture, new Rectangle(Position.X + fixoff.X, Position.Y + fixoff.Y, Width / 2, Height / 2), Chunks.TL[Value.TL], Color.White, 0f, new Vector2(0f, 0f), SpriteEffects.None, 0f);
            RenderContext.SpriteBatch.Draw(Tileset.Texture, new Rectangle(Position.X + Width / 2 + fixoff.X, Position.Y + fixoff.Y, Width / 2, Height / 2), Chunks.TR[Value.TR], Color.White, 0f, new Vector2(0f, 0f), SpriteEffects.None, 0f);
            RenderContext.SpriteBatch.Draw(Tileset.Texture, new Rectangle(Position.X + fixoff.X, Position.Y + Height / 2 + fixoff.Y, Width / 2, Height / 2), Chunks.BL[Value.BL], Color.White, 0f, new Vector2(0f, 0f), SpriteEffects.None, 0f);
            RenderContext.SpriteBatch.Draw(Tileset.Texture, new Rectangle(Position.X + Width / 2 + fixoff.X, Position.Y + Height / 2 + fixoff.Y, Width / 2, Height / 2), Chunks.BR[Value.BR], Color.White, 0f, new Vector2(0f, 0f), SpriteEffects.None, 0f);
        }
    }
}