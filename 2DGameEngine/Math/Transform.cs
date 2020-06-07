﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Math
{
    public struct Transform
    {
        public Point Position;
        public Point Size;
        public Vector2 Origin;
        public float Scale;
        public float Rotation;

        public Transform(Point position=new Point(), Point size=new Point(), float scale=1f, float rotation=0f, Vector2 origin=new Vector2())
        {
            Position = position;
            Size = size;
            Scale = scale;
            Rotation = rotation;
            Origin = origin;
        }
    }
}