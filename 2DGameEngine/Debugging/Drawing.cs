using _2DGameEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace _2DGameEngine.Debugging
{
    public static class Drawing
    {
        static List<object> objects = new List<object>();
        public static void AddObject(object obj)
        {
            if (!objects.Contains(obj)) objects.Add(obj);
        }
        public static void Draw(Circle circle)
        {
            AddObject(circle);
        }
        public static void Draw(Rectangle rectangle)
        {
            AddObject(rectangle);
        }
        private static void drawCircle(Circle circle)
        {
            int width = circle.Radius*2;
            int height = width;

            Color[] dataColors = new Color[width * height];
            int i = 0;
            for (int x = (int)circle.Center.X - width/2; x < circle.Center.X + width/2; x++)
            {
                for(int y = (int)circle.Center.Y - height/2; y< circle.Center.Y + height/2; y++)
                {
                    Vector2 point = new Vector2(x, y);
                    Vector2 center = new Vector2(circle.Center.X, circle.Center.Y);
                    if (Vector2.Distance(point, center) <= circle.Radius)
                    {
                        dataColors[i] = Color.White;
                    }
                    i++;
                }

            }
            Texture2D texture = new Texture2D(RenderContext.Graphics.GraphicsDevice, width, height);
            texture.SetData(0, new Rectangle(0, 0, width, height), dataColors, 0, width * height);
            RenderContext.SpriteBatch.Draw(texture, new Vector2(circle.Center.X-width/2, circle.Center.Y-height/2), Color.White);
        }
        private static void drawRect(Rectangle rect)
        {
            Texture2D text = new Texture2D(RenderContext.Graphics.GraphicsDevice, rect.Width, rect.Height);
            Color[] data = new Color[rect.Width * rect.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            text.SetData(data);

            RenderContext.SpriteBatch.Draw(text, new Vector2(rect.X, rect.Y), Color.White);
        }
        public static void DrawObjects()
        {
            for(int i = 0; i<objects.Count; i++)
            {
                object obj = objects[i];
                if(obj is Circle circle)
                {
                    drawCircle(circle);
                }
                else if(obj is Rectangle rect)
                {
                    drawRect(rect);
                }
            }

        }
    }
}
