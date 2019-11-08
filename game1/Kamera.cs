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
        public Matrix transformMapa;
        public Matrix transformGracz;
        float Zoom = 1f;
        GraphicsDevice Widok;
        Vector2 Srodek;
        public Vector2 kameraMax;
        public Kamera(GraphicsDevice nowyWidok)
        {
            Widok = nowyWidok;
            kameraMax = new Vector2(Resources.mapa.Height  -(1280 / Zoom / 2),
            Resources.mapa.Width-(1024 / Zoom / 2));


        }

        //JESLI KAMERA WYCHODZI POZA MAPE NIE ZMIENIA POLOZENIA
        public void Update(GameTime gameTime, Postac postac)
        {
            Srodek = new Vector2(1280/2,1024/2);

            Widok.Viewport = new Viewport(0, 0, 1280, 1024);
            transformMapa = Matrix.CreateTranslation(-(int)postac.Hitbox.X,
                -(int)postac.Hitbox.Y, 0) *                                             //ZMIANA USTAWIENIA MAPY POD WPLYWEM RUCHU BOHATERA
                Matrix.CreateRotationZ(0) *
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
                Matrix.CreateTranslation(new Vector3(Srodek, 0));


            
                transformGracz = Matrix.CreateTranslation(-(int)postac.Hitbox.X,
               -(int)postac.Hitbox.Y - 100, -100) *                                             //ZMIANA USTAWIENIA GRACZA WZGLEDEM KAMERY POD WPLYWEM RUCHU BOHATERA
                Matrix.CreateRotationZ(0) *
               Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
               Matrix.CreateTranslation(new Vector3(Srodek, 0));
            

            

        }
       



    }
}
