using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DGameEngine
{
    public static class RenderContext
    {
        public static Game Game { get; set; }
        public static ContentManager Content { get { return Game.Content; } }
        public static GraphicsDeviceManager Graphics { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
    }
}
