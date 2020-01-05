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
    /// Kamera
    /// </summary>
    class Kamera
    {
        /// <summary>
        /// składowa x
        /// </summary>
        private int x;
        /// <summary>
        /// składowa y
        /// </summary>
        private int y;
        /// <summary>
        /// tranformowanie wszystkich elementów pod wpływem ruchu gracza
        /// </summary>
        public Matrix transformGracz;
        /// <summary>
        /// zoom
        /// </summary>
        float Zoom = 1f;
        /// <summary>
        /// szybkość wyświetlanych klatek w sekundach
        /// </summary>
        float delta;
        /// <summary>
        /// obszar okna
        /// </summary>
        GraphicsDevice Widok;
        /// <summary>
        /// wyliczenie środka obszaru
        /// </summary>
        Vector2 Srodek;
        /// <summary>
        /// pozycja kamery
        /// </summary>
        public Vector2 pozycja_kamera;
        /// <summary>
        /// odświeżanie
        /// </summary>
        bool update = true;
        /// <summary>
        /// Obsługa kamery
        /// </summary>
        public Kamera(GraphicsDevice nowyWidok)
        {
            Widok = nowyWidok;
            Widok.Viewport = new Viewport(0, 0, 1280, 1024);
            y = (Mapa.mapa_1.GetLength(0) * 64) * (int)Zoom;
            x = (Mapa.mapa_1.GetLength(1) * 64) * (int)Zoom;

        }

        //JESLI KAMERA WYCHODZI POZA MAPE NIE ZMIENIA POLOZENIA
        /// <summary>
        /// Odświeżanie kamery
        /// </summary>
        /// <param name="gameTime">czas gry</param>
        /// <param name="postac">wczytywanie pozycji i ruchu postaci</param>
        public void Update(GameTime gameTime, Postac postac)
        {
            while (update == true)
            {

                pozycja_kamera = new Vector2(Postac.p_startowy.X, Postac.p_startowy.Y);

                if (Postac.p_startowy.X - 640 < 0)
                {
                    while (pozycja_kamera.X < 640)
                    {
                        pozycja_kamera.X += 5;
                    }
                    while (pozycja_kamera.X > x)
                    {
                        pozycja_kamera.X -= 5;
                    }
                }
                if (Postac.p_startowy.Y + 512 < y)
                {
                    while (pozycja_kamera.Y < y)
                    {
                        pozycja_kamera.Y += 5;
                    }
                    while (pozycja_kamera.Y > y)
                    {
                        pozycja_kamera.Y -= 5;
                    }
                }

                update = false;
            }
            var przemieszczenie = (int)postac.przyspieszenie.Y;
            if ((int)postac.przyspieszenie.Y >= 10)
            {
                przemieszczenie = 6;
            }
            else if ((int)postac.przyspieszenie.Y <= -10)
            {
                przemieszczenie = -6;
            }
            Srodek = new Vector2(1280 / 2 - (int)postac.przyspieszenie.X * 0.75f, 1024 / 2 - przemieszczenie * 0.15f);
            delta = (int)gameTime.ElapsedGameTime.TotalSeconds;

            if ((postac.Hitbox.X - 640 > 0 && postac.Hitbox.X + 640 < x))
            {

                if (pozycja_kamera.X < postac.Hitbox.X)
                {
                    pozycja_kamera.X += 5;
                }
                if (pozycja_kamera.X > postac.Hitbox.X)
                {
                    pozycja_kamera.X -= 5;
                }
                if (pozycja_kamera.X > postac.Hitbox.X && pozycja_kamera.X < postac.Hitbox.X)
                {
                    pozycja_kamera.X = postac.Hitbox.X;
                }


            }
            if (postac.Hitbox.Y + 512 < y && postac.Hitbox.Y - 512 > 0)
            {
                while (pozycja_kamera.Y < postac.Hitbox.Y)
                {
                    pozycja_kamera.Y += 5;
                }
                while (pozycja_kamera.Y > postac.Hitbox.Y)
                {
                    pozycja_kamera.Y -= 5;
                }

                System.Diagnostics.Debug.WriteLine("KAMERA Y");


            }




            transformGracz = Matrix.CreateTranslation(-(int)pozycja_kamera.X,
           -(int)pozycja_kamera.Y, 0) *
           Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
           Matrix.CreateTranslation(new Vector3(Srodek, 0));
        }
        
    }
}
