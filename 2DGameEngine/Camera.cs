﻿using _2DGameEngine.Entities;
using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;

namespace _2DGameEngine
{
    public class Camera : Entity
    {
        public float Zoom { get; set; }
        public Matrix TransformMatrix
        {
            get
            {
                return Matrix.CreateTranslation(-Transform.Position.X, -Transform.Position.Y, 0f)*Matrix.CreateScale(Zoom);
            }
        }
    }
}
