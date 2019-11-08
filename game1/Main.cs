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
        public Main(GraphicsDevice graphicsDevice)
        {
            _kamera = new Kamera(graphicsDevice);
            akt_postac = new Postac(graphicsDevice);
            mapa1 = new Mapa(graphicsDevice);
            _podloga = new Podloga(graphicsDevice);
            _podloga.wczytaj();
        }
        public void Update(MouseState mysz,KeyboardState klawiatura,GameTime gameTime)
        {
            _kamera.Update(gameTime, akt_postac);
            akt_postac.Update(mysz,klawiatura,gameTime);
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, _kamera.transformGracz);
            spriteBatch.Draw(Resources.mapa, new Rectangle(0, 0, Resources.mapa.Height, Resources.mapa.Width), Color.White);
            mapa1.Draw(spriteBatch, _kamera);
            _podloga.Draw(spriteBatch);

            spriteBatch.End();
            akt_postac.Draw(spriteBatch,_kamera);
            
        }
    }
}
