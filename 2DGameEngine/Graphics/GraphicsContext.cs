using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGameEngine.Graphics
{
    public static class GraphicsContext
    {
        public static Texture2D CreateRectangle(int width, int height, Color color)
        {
            Texture2D texture = new Texture2D(RenderContext.Graphics.GraphicsDevice, width, height);
            Color[] data = new Color[width * height];
            for(int i = 0; i<data.Length; i++)
            {
                data[i] = color;
            }
            texture.SetData(data);
            return texture;
        } 
    }
}
