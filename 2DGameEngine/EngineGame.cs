using _2DGameEngine.Entities;
using _2DGameEngine.Particles;
using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _2DGameEngine
{
    public class EngineGame : Game
    {
        public EngineGame()
        {
            IsMouseVisible = true;
            RenderContext.Game = this;
            RenderContext.Graphics = new GraphicsDeviceManager(this);
            RenderContext.Graphics.PreferredBackBufferWidth = 1280;
            RenderContext.Graphics.PreferredBackBufferHeight = 720;
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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Scene.Instance.Draw();
            base.Draw(gameTime);
        }
    }
}
