using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{

    class Kolizja
    {
        protected Texture2D _pKolizji;
        protected Texture2D _texture;
        public Kolizja(Texture2D texture, GraphicsDevice graphicsDevice)
        {
            _texture = texture;
            Punkty_kolizji(texture, graphicsDevice);
        }
        public void Punkty_kolizji(Texture2D texture, GraphicsDevice graphicsDevice)
        {
            var colours = new List<Color>();
            for (int y = 0; y < 64; y++)
            {
                for (int x = 0; x < 64; x++)
                {
                    if (y == 0 || // On the top
                        x == 9 || // On the left
                        y == 64 - 1 || // on the bottom
                        x == 64 - 9) // on the right
                    {
                        colours.Add(new Color(255, 255, 255, 255)); // white
                    }
                    else if (y == 9 || x == 0 || y == 64 - 9 || x == 64 - 1)
                    {
                        colours.Add(new Color(255, 255, 255, 255)); // white
                    }
                    else
                    {
                        colours.Add(new Color(0, 0, 0, 0)); // transparent 
                    }
                }
            }
            _pKolizji = new Texture2D(graphicsDevice, 64, 64);
            _pKolizji.SetData<Color>(colours.ToArray());
        }

        public virtual void Draw(SpriteBatch spriteBatch, Rectangle Position)
        {

            //   spriteBatch.Draw(_pKolizji, Position, Color.Black);
        }
    }
}
