using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    class Main
    {
        Mapa mapa1;
        Postac akt_postac;
        Kamera _kamera;
        Podloga _podloga;
        public static RenderTarget2D darkness;
        public static RenderTarget2D mainTarget;
        public Main(GraphicsDevice graphicsDevice)
        {
            _kamera = new Kamera(graphicsDevice);
            akt_postac = new Postac(graphicsDevice);
            mapa1 = new Mapa(graphicsDevice);
            _podloga = new Podloga(graphicsDevice);
            _podloga.wczytaj();
            darkness = new RenderTarget2D(graphicsDevice, Mapa.mapa_1.GetLength(1) * 64, Mapa.mapa_1.GetLength(0) * 64);
            mainTarget = new RenderTarget2D(graphicsDevice, Mapa.mapa_1.GetLength(1) * 64, Mapa.mapa_1.GetLength(0) * 64);


        }
        public void Update(MouseState mysz,KeyboardState klawiatura,GameTime gameTime)
        {
            akt_postac.Update(mysz,klawiatura,gameTime);
            _kamera.Update(gameTime, akt_postac);

        }
        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            

            graphicsDevice.SetRenderTarget(darkness);
            graphicsDevice.Clear(Color.Black);
            var blend = new BlendState
            {
                AlphaSourceBlend = Blend.Zero,
                AlphaDestinationBlend = Blend.InverseSourceColor,
                ColorSourceBlend = Blend.Zero,
                ColorDestinationBlend = Blend.InverseSourceColor,
            };
           
            spriteBatch.Begin(SpriteSortMode.Immediate, blendState:blend);

            spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X +64 , akt_postac.Hitbox.Y ), null, Color.Black * 0.15f, 0, new Vector2(128, 128), 20f, SpriteEffects.None, 0);
            spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X +64, akt_postac.Hitbox.Y ), null, Color.Black * 0.25f, 0, new Vector2(128, 128), 3f, SpriteEffects.None, 0);
            spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X +64, akt_postac.Hitbox.Y ), null, Color.Black * 0.5f, 0, new Vector2(128, 128), 2f, SpriteEffects.None, 0);
            spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X + 64, akt_postac.Hitbox.Y), null, Color.Black * 0.75f, 0, new Vector2(128, 128), 1.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X + 64, akt_postac.Hitbox.Y), null, Color.Black * 0.85f, 0, new Vector2(128, 128), 0.8f, SpriteEffects.None, 0);

            spriteBatch.End();

            graphicsDevice.SetRenderTarget(null);
            graphicsDevice.Clear(Color.Black);
            graphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            spriteBatch.Begin(transformMatrix: _kamera.transformGracz);
            spriteBatch.Draw(darkness, Vector2.Zero, Color.Black);
            spriteBatch.End();

            spriteBatch.Begin(transformMatrix: _kamera.transformGracz);
            spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X +64, akt_postac.Hitbox.Y), null, Color.Red * 0.1f, 0, new Vector2(128, 128), 1.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X +64, akt_postac.Hitbox.Y), null, Color.Red * 0.05f, 0, new Vector2(128, 128), 0.75f, SpriteEffects.None, 0);
            akt_postac.Draw(spriteBatch, _kamera);

            spriteBatch.End();


        }

    }
}
