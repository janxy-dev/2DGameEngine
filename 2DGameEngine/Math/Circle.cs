using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Math
{
    public struct Circle
    {
        public Vector2 Center { get; set; }
        public int Radius { get; set; }
        public Circle(Vector2 center, int radius)
        {
            Center = center;
            Radius = radius;
        }
    }
}
