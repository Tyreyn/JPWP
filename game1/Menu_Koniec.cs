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
    class Menu_Koniec
    {
        public Przycisk Wyjscie;
        public List<Przycisk> Przyciski_Pauza = new List<Przycisk>();

        public Menu_Koniec(GraphicsDevice graphicsDevice)
        {

            
            Wyjscie = new Przycisk(false, false, Resources.M_KONIEC,
                    new Rectangle(1280 / 2 - 150, 500, 300, 100), new Rectangle(0, 56, 300, 100));
            Przyciski_Pauza.Add(Wyjscie);
        }
        public void Stan_Gry()
        {
            if (Wyjscie.czy_klikniety == true)
            {
                Main.Akt_Stan = Main.Stan_Gry.Wyjscie;
                Wyjscie.czy_klikniety = false;
            }
            
        }
        public void Update(GameTime gametime, MouseState mysz)
        {

            var Kursor = new Rectangle(mysz.Position.X, mysz.Position.Y, 1, 1);
            foreach (Przycisk przycisk in Przyciski_Pauza)
            {
                if (Kursor.Intersects(new Rectangle((int)przycisk.pozycja.X, (int)przycisk.pozycja.Y, 300, 100)))
                {
                    if (przycisk.kolor.A == 255) przycisk.czy_najechano = false;
                    if (przycisk.kolor.A == 0) przycisk.czy_najechano = true;
                    if (przycisk.czy_najechano) przycisk.kolor.A += 3; else przycisk.kolor.A -= 3;
                    if (mysz.LeftButton == ButtonState.Pressed)
                    {
                        przycisk.czy_klikniety = true;

                    }
                    System.Diagnostics.Debug.WriteLine("NAJECHANO PAUZA");


                }
                else if (przycisk.kolor.A < 255)
                {
                    przycisk.kolor.A += 3;
                    przycisk.czy_klikniety = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Resources.niebo, new Rectangle(0, 0, 1280, 1024), new Rectangle(0, 0, 320, 240), Color.White);
            spriteBatch.DrawString(Resources.Czcionka, string.Format("ZDOBYLES {0}/3 PUNKTOW", Postac.Star), new Vector2(350, 200), Color.White);
            if (Postac.HP <= 0) spriteBatch.DrawString(Resources.Czcionka, string.Format("ZGINALES"), new Vector2(550, 400), Color.White);
            spriteBatch.Draw(Wyjscie.texture, Wyjscie.pozycja, Wyjscie.rozmiar, Wyjscie.kolor);
            spriteBatch.End();
        }
    }
}
