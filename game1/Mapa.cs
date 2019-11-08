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
    class Mapa
    {
        Kolizja _kolizja;
        public static readonly int MapWidth = Resources.mapa.Width;
        public static readonly int MapHeight = Resources.mapa.Height;
        public static readonly int titleHeight = 64;
        public static readonly int titleWidth = 64;
        public static readonly int SpriteWidth = 51;
        public static readonly int SpriteHeight = 47;
        public static readonly int[,] mapa_1 = new int[,]{
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1},
                {1,0,0,1,0,0,0,0,1,0,0,0,1,0,1,0,0,1,0,0,0,0,0,1},
                {1,1,1,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,1},
                {1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,1,1,0,0,1,1,0,0,0,1,1,0,0,0,0,1,1,1,1,1},
                {1,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1},
                {1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,1,1},
                {1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,1,1,0,0,0,0,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            };
        public Mapa(GraphicsDevice graphicsDevice)
        {
            _kolizja = new Kolizja(Resources.p, graphicsDevice);
        }
        public void Draw(SpriteBatch spriteBatch, Kamera _kamera)
        {
            int i = 0, j = 0;


            foreach (int element in mapa_1)
            {
                if (j == 24)
                {
                    j = 0;
                    i++;
                }
                if (element == 1)
                {


                    spriteBatch.Draw(Resources.p, new Vector2(j * 64, i * 64), new Rectangle(0, 0, 64, 64), Color.Red);


                }
                j++;
            }


        }
    }
}


