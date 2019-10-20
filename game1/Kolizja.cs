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
        protected Texture2D _rectangleTexture;

        protected Texture2D _texture;

        public Kolizja(Texture2D texture,GraphicsDevice graphicsDevice)
        {
            _texture = texture;
            SetRectangleTexture(texture, graphicsDevice);
        }
        private void SetRectangleTexture(Texture2D texture, GraphicsDevice graphicsDevice)
        {
            var colours = new List<Color>();

            for (int y = 0; y < 51; y++)
            {
                for (int x = 0; x < 47; x++)
                {
                    if (y == 0 || // On the top
                        x == 0 || // On the left
                        y == 51 - 1 || // on the bottom
                        x == 47 - 1) // on the right
                    {
                        colours.Add(new Color(255, 255, 255, 255)); // white
                    }
                    else
                    {
                        colours.Add(new Color(0, 0, 0, 0)); // transparent 
                    }
                }
            }

            _rectangleTexture = new Texture2D(graphicsDevice, 51, 47);
            _rectangleTexture.SetData<Color>(colours.ToArray());
        }
        public virtual void Draw(SpriteBatch spriteBatch, Rectangle Position)
        {
           
                    spriteBatch.Draw(_rectangleTexture, Position ,Color.Red);

        }
    }
    
}
