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
    class Resources
    { 
        public static SpriteFont Czcionka;
        public static Texture2D Postac;
        public static Texture2D mapa;
        public static Texture2D p, n,las,niebo,jaskinia;
        public static Texture2D lightMask;
        public static Effect effect1;

        public static void LoadContent(ContentManager Content)
        {
            Czcionka = Content.Load<SpriteFont>("Czcionka");
            Postac = Content.Load<Texture2D>("Postac/postac");
            mapa = Content.Load<Texture2D>("test_map");
            las = Content.Load<Texture2D>("las");
            niebo = Content.Load<Texture2D>("niebo");
            jaskinia = Content.Load<Texture2D>("jaskinia");
            p = Content.Load<Texture2D>("Mapa/ziemia");
            n = Content.Load<Texture2D>("Mapa/niebo");
            effect1 = Content.Load<Effect>("swiatlo");
            lightMask = Content.Load<Texture2D>("lightmask");
        }

    }
}
