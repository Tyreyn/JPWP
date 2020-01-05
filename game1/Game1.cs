using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game1
{
    /// <summary>
    /// Główna pętla gry
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        /// <summary>
        /// opis okna maski światła
        /// </summary>
        public static RenderTarget2D lightsTarget;
        /// <summary>
        /// opis głownego okna
        /// </summary>
        public static RenderTarget2D mainTarget;
        /// <summary>
        /// odwołanie do samego siebie(w celu wyłączenia)
        /// </summary>
        public static Game1 self;
        /// <summary>
        /// odwołanie do głównej pętli
        /// </summary>
        Main _main;
        /// <summary>
        /// Opis głównej pętli
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            self = this;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.ApplyChanges();
        }
        /// <summary>
        /// Inicjalizacja okna
        /// </summary>
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
        /// <summary>
        /// Wczytywanie kontentu
        /// </summary>
        protected override void LoadContent()
        {
            

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Resources.LoadContent(Content);
            _main = new Main(graphics.GraphicsDevice);
            
        }


        /// <summary>
        /// funkcja odświeżania 
        /// </summary>
        protected override void Update(GameTime gameTime)
        {

            
            _main.Update(Mouse.GetState(), Keyboard.GetState(),gameTime);//odświeżanie programu 
            base.Update(gameTime);
        }

        /// <summary>
        /// funkcja odpowiedzialna za rysowanie
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {

            _main.Draw(spriteBatch, GraphicsDevice);
           
            base.Draw(gameTime);
        }
    }
}
