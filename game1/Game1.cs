using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game1
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public int MyszX, MyszY;
        public static RenderTarget2D lightsTarget;
        public static RenderTarget2D mainTarget;

        Main _main;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 1024;
            graphics.PreferredBackBufferWidth = 1280;
            lightsTarget = new RenderTarget2D(
            GraphicsDevice, 1280, 1024);
            mainTarget = new RenderTarget2D(
            GraphicsDevice, 1280, 1024);
            graphics.ApplyChanges();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Resources.LoadContent(Content);
            _main = new Main(graphics.GraphicsDevice);
            
        }

        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {

             MyszX = Mouse.GetState().X;
             MyszY = Mouse.GetState().Y;
            _main.Update(Mouse.GetState(), Keyboard.GetState(),gameTime);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {

            _main.Draw(spriteBatch, GraphicsDevice);
           
            base.Draw(gameTime);
        }
    }
}
