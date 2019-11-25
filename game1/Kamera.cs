using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    class Kamera
    {
        private int x,y;
        public Matrix transformGracz;
        float Zoom = 1;
        float delta;
        GraphicsDevice Widok;
        Vector2 Srodek;
        public Vector2 pozycja_kamera;
        bool update = true;
        public Kamera(GraphicsDevice nowyWidok)
        {
            Widok = nowyWidok;
            Widok.Viewport = new Viewport(0, 0, 1280, 1024);
            y = (Mapa.mapa_1.GetLength(0)*64)*(int)Zoom;
            x = (Mapa.mapa_1.GetLength(1)*64)*(int)Zoom;
            
        }

        //JESLI KAMERA WYCHODZI POZA MAPE NIE ZMIENIA POLOZENIA
        public void Update(GameTime gameTime, Postac postac)
        {
            while (update == true)
            {

                pozycja_kamera = new Vector2(postac.p_startowy.X, postac.p_startowy.Y);

                if (postac.p_startowy.X - 640 < 0){ 
                while (pozycja_kamera.X < 640)
                {
                    pozycja_kamera.X += 5;
                }
                while (pozycja_kamera.X > x)
                {
                    pozycja_kamera.X -= 5;
                }
            }

                update = false;
            }
            Srodek = new Vector2(1280 / 2 - (int)postac.przyspieszenie.X *1.25f , 1024 / 2 - (int)postac.przyspieszenie.Y * 0.75f);
            delta = (int)gameTime.ElapsedGameTime.TotalSeconds;

            if ((postac.Hitbox.X - 640 > 0 && postac.Hitbox.X + 640 < x ))
            {
                
                if(pozycja_kamera.X < postac.Hitbox.X)
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
            if (postac.Hitbox.Y +540< y  && postac.Hitbox.Y - 540 > 0)
            {
                
                    pozycja_kamera.Y = postac.Hitbox.Y;
                
            }
            



            transformGracz = Matrix.CreateTranslation(-(int)pozycja_kamera.X ,
           -(int)pozycja_kamera.Y , 0) *
           Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
           Matrix.CreateTranslation(new Vector3(Srodek, 0));
        }

    }
}
