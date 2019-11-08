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
        public static Texture2D p, n;

        public static void LoadContent(ContentManager Content)
        {
            Czcionka = Content.Load<SpriteFont>("Czcionka");
            Postac = Content.Load<Texture2D>("Postac/crowley_wings");
            mapa = Content.Load<Texture2D>("test_map");
            p = Content.Load<Texture2D>("Mapa/podloga");
            n = Content.Load<Texture2D>("Mapa/niebo");
        }

    }
}
