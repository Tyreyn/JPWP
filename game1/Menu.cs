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
    public class Przycisk
    {
        public bool czy_klikniety;
        public bool czy_najechano;
        public Texture2D texture;
        public Vector2 pozycja;
        public Rectangle rozmiar;
        public Color kolor = new Color(255, 255, 255, 255);
        public Przycisk(bool czy_najechano,bool czy_klikniety, Texture2D texture, Vector2 pozycja, Rectangle rozmiar)
        {
            this.czy_najechano = czy_najechano;
            this.czy_klikniety = czy_klikniety;
            this.texture = texture;
            this.pozycja = pozycja;
            this.rozmiar = rozmiar;
        }
    }
    class Menu
    {
        public Przycisk Start;
        public Przycisk Wyjscie;
        public Przycisk Pomoc;
        
        public Rectangle Kursor;
        public List<Przycisk> Przyciski = new List<Przycisk>();
        public Menu(GraphicsDevice graphicsDevice)
        {

            Start = new Przycisk(false,false,Resources.p,
                    new Vector2(550, 200), new Rectangle(200, 200, 150, 150));
            Pomoc = new Przycisk(false, false, Resources.p,
                    new Vector2(550, 400), new Rectangle(200, 200, 150, 150));
            Wyjscie = new Przycisk(false,false, Resources.p,
                    new Vector2(550, 600), new Rectangle(200, 200, 150, 150));
            Przyciski.Add(Start);
            Przyciski.Add(Pomoc);
            Przyciski.Add(Wyjscie);
        }
        public Main.Stan_Gry Stan_Gry(Main.Stan_Gry aktualny)
        {
            if (Start.czy_klikniety == true)
            {
                aktualny = Main.Stan_Gry.Gra;
                Start.czy_klikniety = false;
            }else if(Wyjscie.czy_klikniety == true)
            {
                aktualny = Main.Stan_Gry.Wyjscie;
                
                //dodac wyłączenie gry
            }else if(Pomoc.czy_klikniety == true)
            {
                aktualny = Main.Stan_Gry.Koniec;

                Pomoc.czy_klikniety = false;
                //dodać zapis/wczytanie
            }
            return aktualny;
        }
        public void Update(GameTime gametime, MouseState mysz)
        {
            
            Kursor = new Rectangle(mysz.Position.X,mysz.Position.Y,1,1);
           
            foreach(Przycisk przycisk in Przyciski)
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
                    System.Diagnostics.Debug.WriteLine("NAJECHANO");


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
            spriteBatch.Draw(Resources.niebo, new Vector2(0, 0), new Rectangle(0, -500, 2000, 2000), Color.White);
            spriteBatch.Draw(Start.texture,Start.pozycja,Start.rozmiar,Start.kolor);
            spriteBatch.Draw(Wyjscie.texture, Wyjscie.pozycja, Wyjscie.rozmiar, Wyjscie.kolor);
            spriteBatch.Draw(Pomoc.texture, Pomoc.pozycja, Pomoc.rozmiar, Pomoc.kolor);
            
            spriteBatch.End();
        }
    }
}
