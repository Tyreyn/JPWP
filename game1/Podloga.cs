using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    /// <summary>
    /// Opis klocka mapy
    /// </summary>
    public class Klocek
    {
        ///wymiary klocka
        public Rectangle wymiary;
        ///rodzaj klocka 1-podloga 2-spadajaca podloga 3-gwiazda
        public int rodzaj;
        /// <summary>
        /// Opis Klocka
        /// </summary>
        /// <param name="wymiary"></param>
        /// <param name="rodzaj"></param>
        public Klocek(Rectangle wymiary, int rodzaj)
        {
            this.wymiary = wymiary;
            this.rodzaj = rodzaj;
        }
    }
    /// <summary>
    /// Obsługa wczytywania elementów mapy
    /// </summary>
    class Podloga
    {
        public List<Klocek> pKloc = new List<Klocek>();
        public Podloga(GraphicsDevice graphicsDevice)
        {
            wczytaj();
            
        }
        /// <summary>
        /// Wczytywanie elementów mapy
        /// </summary>
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
                else if (element == 3)
                {
                    pKloc.Add(new Klocek(new Rectangle(j * 64, i * 64, 64, 64), 3));
                }
                else if (element == 4)
                {
                    pKloc.Add(new Klocek(new Rectangle(j * 64, i * 64, 64, 64), 4));
                }

            j++;
            }
        }
        /// <summary>
        /// Wyswietlanie mapy
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < pKloc.Count; i++)
            {
                if (pKloc[i].rodzaj == 1)
                {
                    spriteBatch.Draw(Resources.p, new Vector2(pKloc[i].wymiary.X, pKloc[i].wymiary.Y), new Rectangle(165,179,64,64), Color.White);

                }
                else if (pKloc[i].rodzaj == 2)
                {
                    spriteBatch.Draw(Resources.p, new Vector2(pKloc[i].wymiary.X, pKloc[i].wymiary.Y), new Rectangle(165, 179, 64, 64), Color.White);
                }
                else if (pKloc[i].rodzaj == 3)
                {
                    spriteBatch.Draw(Resources.Star, new Rectangle(pKloc[i].wymiary.X, pKloc[i].wymiary.Y,64,64), new Rectangle(0, 0, 512, 512), Color.White);
                }
                else if (pKloc[i].rodzaj == 4)
                {
                    spriteBatch.Draw(Resources.p, new Vector2(pKloc[i].wymiary.X, pKloc[i].wymiary.Y), new Rectangle(165, 179, 64, 64), Color.BlueViolet);
                }
            }
        }
       

    }
}
