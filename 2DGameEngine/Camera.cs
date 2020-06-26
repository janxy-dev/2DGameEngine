﻿using _2DGameEngine.Entities;
using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;

namespace _2DGameEngine
{
    public class Camera : Entity
    {
        public Matrix TransformMatrix
        {
            get
            {
                return Matrix.CreateTranslation(-Transform.Position.X, -Transform.Position.Y, 0f);
            }
        }
        public Camera(Layer layer) : base(layer)
        {
        }
    }
}
