using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    class Podloga
    {
        public List<Rectangle> pKloc = new List<Rectangle>();
        public Podloga(GraphicsDevice graphicsDevice)
        {
            wczytaj();

        }
        public void wczytaj()
        {
            int j = 0, i = 0;
            foreach (int element in Mapa.mapa_1)
            {
                if (j == 24)
                {
                    j = 0;
                    i++;
                }
                if (element == 1)
                {
                    pKloc.Add(new Rectangle(j * 64, i * 64, 64, 64));
                }
                j++;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < pKloc.Count; i++)
            {
                spriteBatch.Draw(Resources.p, pKloc[i], Color.Red);
            }
        }

    }
}
