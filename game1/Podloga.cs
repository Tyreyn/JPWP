using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    public class Klocek
    {
        public Rectangle wymiary;
        public int rodzaj;

        public Klocek(Rectangle wymiary, int rodzaj)
        {
            this.wymiary = wymiary;
            this.rodzaj = rodzaj;
        }
    }
    class Podloga
    {
        public List<Klocek> pKloc = new List<Klocek>();
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
                    pKloc.Add(new Klocek (new Rectangle(j * 64, i * 64, 64, 64),1));
                    

                }else if (element == 2)
                {
                    pKloc.Add(new Klocek(new Rectangle(j * 64, i * 64, 64, 64), 2));
                }
               

                j++;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < pKloc.Count; i++)
            {
                if (pKloc[i].rodzaj == 1)
                {
                    spriteBatch.Draw(Resources.p, new Vector2(pKloc[i].wymiary.X, pKloc[i].wymiary.Y), new Rectangle(0, 0, 64, 64), Color.Red);

                }
                else if (pKloc[i].rodzaj == 2)
                {
                    spriteBatch.Draw(Resources.p, new Vector2(pKloc[i].wymiary.X, pKloc[i].wymiary.Y), new Rectangle(0, 0, 64, 64), Color.Blue);
                }
            }
        }
       

    }
}
