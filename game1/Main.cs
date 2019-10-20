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
        Postac akt_postac;
        Kamera _kamera;
        public Main(GraphicsDevice graphicsDevice)
        {
            _kamera = new Kamera();

            akt_postac = new Postac(graphicsDevice);
        }
        public void Update(MouseState mysz,KeyboardState klawiatura)
        {
            akt_postac.Update(mysz,klawiatura);
            _kamera.Follow(akt_postac.Hitbox);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: _kamera.Transform);
            spriteBatch.Draw(Resources.mapa,new Rectangle(0,0,Resources.mapa.Height/2,Resources.mapa.Width/2),Color.White);
            spriteBatch.End();
            akt_postac.Draw(spriteBatch);


        }
    }
}
