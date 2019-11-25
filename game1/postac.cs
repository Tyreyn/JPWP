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

    //INPUT
    //ANIMACJA
    //TARCIE
    public enum Direction
    {
        Left, Right

    };


    class Postac
    {
        public Vector2 p_startowy;
        public Rectangle Hitbox;
        float Speed = 30;
        public Vector2 przyspieszenie;
        int Szer, Wysok, Czas, SzybAnimacji = 7;
        int MyszX, MyszY;
        bool Animowac;
        int GTime;
        float jumpVelocity = 1300;
        float G = 0.75f;
        float friction = 0.5f;
        bool devMod = true;
        bool applyGravity = true;
        KeyboardState poprzedniStan;
        bool spadanie, skok;
        public int j = 0, i = 0;
        float delta;
        Podloga _podloga;
        Kolizja _kolizja;
        public Postac(GraphicsDevice graphicsDevice)
        {
            p_startowy = new Vector2(400, 644);
            _kolizja = new Kolizja(Resources.Postac, graphicsDevice);
            this.Hitbox = new Rectangle((int)p_startowy.X, (int)p_startowy.Y, 40, 50);
            this.Szer = 4;
            this.Wysok = 1;
            this.Animowac = true;
            this.przyspieszenie = new Vector2(0, 0);
            poprzedniStan = Keyboard.GetState();
            _podloga = new Podloga(graphicsDevice);


        }
        public void Animacja()
        {

            this.Czas++;

            if (this.Czas == this.SzybAnimacji && Math.Abs(this.przyspieszenie.X) >= 0)
            {
                this.Czas = 0;
                if (this.Animowac)
                {
                    this.Szer++;
                    if (this.Szer > 4)
                    {
                        this.Szer = 3;
                        this.Animowac = false;
                    }
                }
                else
                {
                    this.Szer--;
                    if (this.Szer < 1)
                    {
                        this.Szer = 2;
                        this.Animowac = true;
                    }
                }

            }

        }
        public void Update(MouseState mysz, KeyboardState klawiatura, GameTime gameTime)
        {
            skok = false;
            MyszX = mysz.Position.X;
            MyszY = mysz.Position.Y;
            delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (spadanie == true)
            {
                this.przyspieszenie.Y += G;
            }
            
            if (applyGravity == true) this.przyspieszenie.Y += G;
            Ruch(klawiatura);
            GTime++;
            

            for (int i = 0; i < _podloga.pKloc.Count; i++)
            {
                if (IntersectsFromTop(Hitbox, _podloga.pKloc[i]))
                {
                    System.Diagnostics.Debug.WriteLine("WYKRYTO KOLIZJA GORA");
                    this.Hitbox.Y = Hitbox.Y - (int)this.przyspieszenie.Y;
                    this.przyspieszenie.Y = 0;
                    skok = true;
                    spadanie = false;
                }
                else if (IntersectsFromRight(Hitbox, _podloga.pKloc[i]))
                {
                    System.Diagnostics.Debug.WriteLine("WYKRYTO KOLIZJA PRAWO");
                    this.Hitbox.X = Hitbox.X - (int)this.przyspieszenie.X;
                //    if ((int)this.przyspieszenie.X <= 0) this.przyspieszenie.X = 0;
                    this.Czas = 0;

                }
                else if (IntersectsFromLeft(Hitbox, _podloga.pKloc[i]))
                {
                    System.Diagnostics.Debug.WriteLine("WYKRYTO KOLIZJA LEWO");
                    this.Hitbox.X = Hitbox.X - (int)this.przyspieszenie.X;
                 //   if ((int)this.przyspieszenie.X >= 0) this.przyspieszenie.X = 0;

                    this.Czas = 0;
                }
                else if (IntersectsFromDown(Hitbox, _podloga.pKloc[i]))
                {
                    System.Diagnostics.Debug.WriteLine("WYKRYTO KOLIZJA DOL");
                    this.Hitbox.Y = Hitbox.Y + (int)this.przyspieszenie.Y;
                    this.przyspieszenie.Y = 0;
                    spadanie = true;
                }
            }

        }
        public void Ruch(KeyboardState klawiatura)
        {

            if (klawiatura.IsKeyDown(Keys.A) && klawiatura.IsKeyDown(Keys.D))
            {
                this.przyspieszenie.X = 0;
                this.Wysok = 1;
                this.Czas = 0;
            }
            if (klawiatura.IsKeyDown(Keys.D) && poprzedniStan.IsKeyDown(Keys.D))
            {

                if (this.przyspieszenie.X <= 6) this.przyspieszenie.X += this.Speed * delta;
                this.Wysok = 3;
                this.Animacja();
                System.Diagnostics.Debug.WriteLine("Wcisnieto D");


            }
            if (klawiatura.IsKeyDown(Keys.A) && poprzedniStan.IsKeyDown(Keys.A))
            {
                if (this.przyspieszenie.X >= -6) this.przyspieszenie.X -= this.Speed * delta;
                this.Wysok = 2;
                this.Animacja();
                System.Diagnostics.Debug.WriteLine("Wcisnieto A");


            }


            if (klawiatura.IsKeyUp(Keys.F1) && poprzedniStan.IsKeyDown(Keys.F1))
            {
                devMod = !devMod;
                System.Diagnostics.Debug.WriteLine("Wcisnieto F1");

            }

            if (klawiatura.IsKeyDown(Keys.W) && spadanie == false && skok == false)
            {
                skok = true;
                spadanie = true;
                if (this.przyspieszenie.Y > -4)
                    this.przyspieszenie.Y -= jumpVelocity* this.delta;

                System.Diagnostics.Debug.WriteLine("Wcisnieto W");
            }

            if (klawiatura.IsKeyUp(Keys.A) && klawiatura.IsKeyUp(Keys.D))
            {

                this.Szer = 1;
                this.Wysok = 1;
                this.Czas = 0;
                if (this.przyspieszenie.X > 0)
                {
                    this.przyspieszenie.X -= friction;
                }
                else if (this.przyspieszenie.X < 0)
                {
                    this.przyspieszenie.X += friction;
                }
            }

            this.Hitbox.Y += (int)this.przyspieszenie.Y;
            this.Hitbox.X += (int)this.przyspieszenie.X;
            poprzedniStan = Keyboard.GetState();
        }

        public void Draw(SpriteBatch spriteBatch, Kamera _kamera)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, _kamera.transformGracz);
            spriteBatch.Draw(Resources.Postac, this.Hitbox, new Rectangle((this.Szer - 1) * 51, (this.Wysok - 1) * 47, 51, 47), Color.White);
            if (devMod == true) _kolizja.Draw(spriteBatch, Hitbox);
            spriteBatch.End();

            spriteBatch.Begin();
            if (devMod == true)
            {
                spriteBatch.DrawString(Resources.Czcionka, string.Format("KOORDYNATY X:{0}   Y:{1}", this.Hitbox.X, this.Hitbox.Y), new Vector2(0, 0), Color.Black);
                spriteBatch.DrawString(Resources.Czcionka, string.Format("CZAS GRY:{0}", GTime), new Vector2(0, 25), Color.Black);
                spriteBatch.DrawString(Resources.Czcionka, string.Format("PREDKOSC:{0}  GRAWITACJA:{1}", (int)this.przyspieszenie.X, (int)this.przyspieszenie.Y), new Vector2(0, 50), Color.Black);
                spriteBatch.DrawString(Resources.Czcionka, string.Format("MYSZ X:{0}  MYSZ Y:{1}", MyszX, MyszY), new Vector2(0, 75), Color.Black);
                spriteBatch.DrawString(Resources.Czcionka, string.Format("CAM X:{0}  CAM Y:{1}", _kamera.pozycja_kamera.X, _kamera.pozycja_kamera.Y), new Vector2(0, 100), Color.Black);
                spriteBatch.DrawString(Resources.Czcionka, string.Format("MAP X:{0}  MAP Y:{1}", Resources.mapa.Height, Resources.mapa.Width), new Vector2(0, 125), Color.Black);

            }
            spriteBatch.End();

        }
        #region wykrywanie_kolizji
        private static bool IntersectsFromRight(Rectangle postac, Rectangle obiekt)
        {
            var kolizja = Rectangle.Intersect(postac, obiekt);
            return postac.Intersects(obiekt) && kolizja.X + kolizja.Width == obiekt.X + obiekt.Width && kolizja.Width <= kolizja.Height;
        }
        private static bool IntersectsFromLeft(Rectangle postac, Rectangle obiekt)
        {
            var kolizja = Rectangle.Intersect(postac, obiekt);
            return postac.Intersects(obiekt) && kolizja.X == obiekt.X && kolizja.Width <= kolizja.Height;
        }

        private static bool IntersectsFromTop(Rectangle postac, Rectangle obiekt)
        {
            var kolizja = Rectangle.Intersect(postac, obiekt);
            return postac.Intersects(obiekt) && kolizja.Y == obiekt.Y && kolizja.Width >= kolizja.Height;
        }
        private static bool IntersectsFromDown(Rectangle postac, Rectangle obiekt)
        {
            var kolizja = Rectangle.Intersect(postac, obiekt);
            return postac.Intersects(obiekt) && kolizja.Y + kolizja.Height == obiekt.Y + obiekt.Height && kolizja.Width >= kolizja.Height;
        }
        #endregion
    }
}
