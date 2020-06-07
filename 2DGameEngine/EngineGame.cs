using _2DGameEngine.Entities;
using _2DGameEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DGameEngine
{
    public class EngineGame : Game
    {
        public EngineGame()
        {
            IsMouseVisible = true;
            RenderContext.Graphics = new GraphicsDeviceManager(this);
            RenderContext.Content = Content;
            RenderContext.Graphics.PreferredBackBufferWidth = 1280;
            RenderContext.Graphics.PreferredBackBufferHeight = 720;
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
            Scene.current.Update();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            RenderContext.SpriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Scene.current.Camera.TransformMatrix);
            Scene.current.Draw();
            RenderContext.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
