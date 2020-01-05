using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace game1
{
    /// <summary>
    ///Wczytanie tekstur do programu
    /// </summary>
    class Resources
    {
        /// <summary>
        /// tekstura czcionki
        /// </summary>
        public static SpriteFont Czcionka;

        /// <summary>
        /// tekstura postaci
        /// </summary>
        public static Texture2D Postac;
        /// <summary>
        /// tekstura tła i elementów w grze
        /// </summary>
        public static Texture2D p, n, las, niebo, jaskinia;
        /// <summary>
        /// tekstura maski światła
        /// </summary>
        public static Texture2D lightMask;
        public static Effect effect1;
        /// <summary>
        /// tekstura gwiazdy w grze
        /// </summary>
        public static Texture2D Star;
        /// <summary>
        /// tekstura przycisku
        /// </summary>
        public static Texture2D M_START, M_KONIEC, M_KONTYNUUJ;
        /// <summary>
        /// tekstura życia i gwiazdek w menu
        /// </summary>
        public static Texture2D NULL, ONE, TWO, THREE, HP3, HP2, HP1;
        /// <summary>
        /// Wczytanie tekstur
        /// </summary>
        public static void LoadContent(ContentManager Content)
        {
            //Za pomocą jednej z funkcji frameworku 
            //wczytywany jest plik z wybranej scieżki


            Czcionka = Content.Load<SpriteFont>("Czcionka");
            Postac = Content.Load<Texture2D>("Postac/postac");
            las = Content.Load<Texture2D>("las");
            M_START = Content.Load<Texture2D>("MENU/START");
            M_KONIEC = Content.Load<Texture2D>("MENU/KONIEC");
            M_KONTYNUUJ = Content.Load<Texture2D>("MENU/KONTYNUUJ");
            niebo = Content.Load<Texture2D>("niebo");
            jaskinia = Content.Load<Texture2D>("jaskinia");
            p = Content.Load<Texture2D>("Mapa/ziemia");
            n = Content.Load<Texture2D>("Mapa/niebo");
            Star = Content.Load<Texture2D>("Mapa/Star");
            NULL = Content.Load<Texture2D>("GUI/puste");
            ONE = Content.Load<Texture2D>("GUI/1na3");
            TWO = Content.Load<Texture2D>("GUI/2na3");
            THREE = Content.Load<Texture2D>("GUI/3na3");
            HP1 = Content.Load<Texture2D>("GUI/3 Cell hearts no border 1 of 3");
            HP2 = Content.Load<Texture2D>("GUI/3 Cell hearts no border 2 of 3");
            HP3 = Content.Load<Texture2D>("GUI/3 Cell hearts no border full");
            effect1 = Content.Load<Effect>("swiatlo");
            lightMask = Content.Load<Texture2D>("lightmask");
        }

    }
}
