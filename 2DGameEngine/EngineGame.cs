using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _2DGameEngine
{
    public class EngineGame : Game
    {
        public Color BackgroundColor { get; set; } = Color.Black;
        public EngineGame()
        {
            IsMouseVisible = true;
            RenderContext.Game = this;
            RenderContext.Graphics = new GraphicsDeviceManager(this);
            RenderContext.Graphics.PreferredBackBufferWidth = 800;
            RenderContext.Graphics.PreferredBackBufferHeight = 480;
            IsFixedTimeStep = false;
            //RenderContext.Graphics.SynchronizeWithVerticalRetrace = false;
            RenderContext.Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            RenderContext.SpriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        protected override void Update(GameTime gameTime)
        {
            Scene.Instance.Update();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackgroundColor);
            Scene.Instance.Draw();
            Console.WriteLine(1f / gameTime.ElapsedGameTime.TotalSeconds);
            base.Draw(gameTime);
        }
    }
}
