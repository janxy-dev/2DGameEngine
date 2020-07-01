using _2DGameEngine.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Graphics
{
    public class SpriteAnimation
    {
        public int Start { get; }
        public int End { get; }
        public int FrameTick { get; set; }
        int tick = 1;
        Sprite sprite;
        public SpriteAnimation(Sprite sprite, int start, int end)
        {
            Start = start;
            End = end;
            this.sprite = sprite;
        }
        public void NextFrame()
        {
            if (tick-1 > 0) { tick--; return; }
            else tick = FrameTick;
            if (sprite.Index >= Start && sprite.Index <= End)
            {
                sprite.Index++;
            }
            else sprite.Index = Start;
            if (sprite.Index > End)
            {
                sprite.Index = Start;
            }
        }
    }
}
