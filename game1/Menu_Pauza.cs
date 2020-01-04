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
    class Menu_Pauza
    {
        public Przycisk Kontynuuj;
        public Przycisk Wyjscie;
        public List<Przycisk> Przyciski_Pauza = new List<Przycisk>();

        public Menu_Pauza(GraphicsDevice graphicsDevice)
        {
            Kontynuuj = new Przycisk(false, false, Resources.p, new Vector2(550, 200), new Rectangle(200, 200, 150, 150));
            Wyjscie = new Przycisk(false, false, Resources.p, new Vector2(550, 400), new Rectangle(200, 200, 150, 150));
            Przyciski_Pauza.Add(Kontynuuj);
            Przyciski_Pauza.Add(Wyjscie);
        }
        public void Stan_Gry()
        {
            if (Kontynuuj.czy_klikniety == true)
            {
                Main.Akt_Stan = Main.Stan_Gry.Gra;
                Kontynuuj.czy_klikniety = false;
            }
            else if (Wyjscie.czy_klikniety == true)
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
                if (Kursor.Intersects(new Rectangle((int)przycisk.pozycja.X, (int)przycisk.pozycja.Y, 150, 150)))
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
            spriteBatch.Draw(Kontynuuj.texture, Kontynuuj.pozycja, Kontynuuj.rozmiar, Kontynuuj.kolor);
            spriteBatch.Draw(Wyjscie.texture, Wyjscie.pozycja, Wyjscie.rozmiar, Wyjscie.kolor);
            spriteBatch.End();
        }
    }
}
