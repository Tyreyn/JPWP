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
    /// <summary>
    /// Klasa przycisku
    /// </summary>
    public class Przycisk
    {
        /// <summary>
        /// Gdy klikniety wykonuje się dana czynność
        /// </summary>
        public bool czy_klikniety;
        /// <summary>
        ///Gdy najechona wykonuje się dana czynność 
        /// </summary>
        public bool czy_najechano;
        /// <summary>
        ///Tekstura przycisku
        /// </summary>
        public Texture2D texture;
        /// <summary>
        ///położenie/rozmiar
        /// </summary>
        public Rectangle pozycja;
        /// <summary>
        ///rozmiar obszaru z pliku z którego ma zostać pobrany obraz
        /// </summary>
        public Rectangle rozmiar;
        /// <summary>
        ///Opis koloru
        /// </summary>
        public Color kolor = new Color(255, 255, 255, 255);
        /// <summary>
        /// Przycisk
        /// </summary>
        /// <param name="czy_najechano"></param>
        /// <param name="czy_klikniety"></param>
        /// <param name="texture"></param>
        /// <param name="pozycja"></param>
        /// <param name="rozmiar"></param>
        public Przycisk(bool czy_najechano,bool czy_klikniety, Texture2D texture, Rectangle pozycja, Rectangle rozmiar)
        {
            this.czy_najechano = czy_najechano;
            this.czy_klikniety = czy_klikniety;
            this.texture = texture;
            this.pozycja = pozycja;
            this.rozmiar = rozmiar;
        }
    }
    /// <summary>
    /// Menu gry
    /// </summary>
    class Menu
    {
        public Przycisk Start;
        public Przycisk Wyjscie;
        
        public Rectangle Kursor;
        public List<Przycisk> Przyciski = new List<Przycisk>();
        public Menu(GraphicsDevice graphicsDevice)
        {

            Start = new Przycisk(false,false,Resources.M_START,
                    new Rectangle(1280/2-150, 300,300,100), new Rectangle(0,56,300,100));
            Wyjscie = new Przycisk(false,false, Resources.M_KONIEC,
                    new Rectangle(1280/2-150, 500,300,100), new Rectangle(0 ,56, 300, 100));
            Przyciski.Add(Start);
            Przyciski.Add(Wyjscie);
        }
        /// <summary>
        /// Odświeżanie stanu gry
        /// </summary>
        /// <param name="aktualny">zczytuje stan gry</param>
        /// <returns></returns>
        public Main.Stan_Gry Stan_Gry(Main.Stan_Gry aktualny)
        {
            if (Start.czy_klikniety == true)
            {
                aktualny = Main.Stan_Gry.Gra;
                Start.czy_klikniety = false;
            }else if(Wyjscie.czy_klikniety == true)
            {
                aktualny = Main.Stan_Gry.Wyjscie;
            }
            return aktualny;
        }
        /// <summary>
        /// Odświeżanie menu
        /// </summary>
        /// <param name="gametime">czas gry</param>
        /// <param name="mysz">zczytywanie ruchu myszy</param>
        public void Update(GameTime gametime, MouseState mysz)
        {
            
            Kursor = new Rectangle(mysz.Position.X,mysz.Position.Y,1,1);
           
            foreach(Przycisk przycisk in Przyciski)
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
            spriteBatch.Draw(Resources.niebo, new Rectangle(0, 0, 1280, 1024), new Rectangle(0, 0, 320, 240), Color.White);
            spriteBatch.Draw(Start.texture,Start.pozycja,Start.rozmiar,Start.kolor);
            spriteBatch.Draw(Wyjscie.texture, Wyjscie.pozycja, Wyjscie.rozmiar, Wyjscie.kolor);            
            spriteBatch.End();
        }
    }
}
