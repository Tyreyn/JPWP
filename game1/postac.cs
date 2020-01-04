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

    class Postac
    {
        public bool isShine = true;
        public float shining;
        public static int Star = 0;
        public static int HP = 3;
        public Vector2 p_startowy;
        public Rectangle Hitbox;
        float spadekKlocka;
        float Speed = 30;
        public Vector2 przyspieszenie;
        int Szer, Wysok, Czas, SzybAnimacji = 5;
        int MyszX, MyszY;
        bool Animowac;
        int GTime;
        float jumpVelocity = 1300;
        float G = 0.8f;
        float friction = 0.75f;
        bool devMod = true;
        bool applyGravity = true;
        KeyboardState poprzedniStan;
        bool spadanie = true, skok, czydalej = false;
        public int j = 0, i = 0, spadajacy;
        float delta;
        Podloga _podloga;
        Kolizja _kolizja;
        Rectangle ruch_postaci;
        SpriteEffects kierunek;
        public Postac(GraphicsDevice graphicsDevice)
        {
            p_startowy = new Vector2(300, 720);
            _kolizja = new Kolizja(Resources.Postac, graphicsDevice);
            this.Hitbox = new Rectangle((int)p_startowy.X, (int)p_startowy.Y, 32, 58);
            this.ruch_postaci = new Rectangle(3, 0, 12, 34);
            this.Szer = 4;
            this.Wysok = 1;
            this.Animowac = true;
            this.przyspieszenie = new Vector2(0, 0);
            poprzedniStan = Keyboard.GetState();
            _podloga = new Podloga(graphicsDevice);
            shining = 0.2f;
        }
        public void Animacja()
        {

            this.Czas++;
            if (this.Wysok == 0 && spadanie == false)
            {
                if (this.Czas == this.SzybAnimacji)
                {
                    this.Czas = 0;
                   
                    if (this.Animowac)
                    {
                        this.Hitbox.Width = 40;
                        this.Szer++;
                        if (this.Szer == 1) this.ruch_postaci = new Rectangle(0, 36, 30, 27);
                        if (this.Szer == 2) this.ruch_postaci = new Rectangle(34, 36, 23, 29);
                        if (this.Szer == 3) this.ruch_postaci = new Rectangle(62, 35, 26, 29);
                        if (this.Szer == 4) this.ruch_postaci = new Rectangle(90, 36, 30, 29);
                        if (this.Szer == 5) this.ruch_postaci = new Rectangle(124, 36, 23, 28);
                        if (this.Szer == 6)
                        {
                            this.ruch_postaci = new Rectangle(152, 35, 26, 29);


                            this.Animowac = false;
                        }
                    }
                    else
                    {
                        

                        this.Szer = 1;
                        if ((int)przyspieszenie.X == 0)
                        {
                            this.Hitbox.Width = 24;
                            this.ruch_postaci = new Rectangle(3, 0, 12, 34);
                        }

                        this.Animowac = true;

                    }

                }
            }
            else if(this.Wysok == 1 )
            {

                    if (this.Animowac && this.przyspieszenie.Y > 0)
                    {
                        this.Szer++;
                        if (this.Szer == 1) this.ruch_postaci = new Rectangle(4, 77, 12, 27);
                        if (this.Szer == 2) this.ruch_postaci = new Rectangle(18, 73, 12, 31);
                        if (this.Szer == 3) this.ruch_postaci = new Rectangle(32, 73, 15, 31);
                        
                            this.Animowac = false;
                    }
                    else
                    {
                        this.Szer = 3;
                        this.Animowac = true;
                     
                    }
                    if (spadanie == true && (int)this.przyspieszenie.Y < 0)
                     {
                    this.ruch_postaci = new Rectangle(48, 65, 16, 39);
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
                if ((int)this.przyspieszenie.Y <= 10) this.przyspieszenie.Y += G;
                if ((int)this.przyspieszenie.Y >= 31) this.przyspieszenie.Y = 31;
                this.ruch_postaci = new Rectangle(48, 65, 16, 39);
                this.Hitbox.Width = 32;
            }

            if (applyGravity == true)
            {
                this.przyspieszenie.Y += G;
            }
            Ruch(klawiatura);
            GTime++;


            for (int i = 0; i < _podloga.pKloc.Count; i++)
            {
                if (IntersectsFromTop(Hitbox, _podloga.pKloc[i].wymiary))
                {
                    if ((int)this.przyspieszenie.Y >= 30) HP--;
                    if (_podloga.pKloc[i].rodzaj == 3)
                        if (this.Hitbox.Intersects(_podloga.pKloc[i].wymiary))
                        {
                            Star++;
                            _podloga.pKloc.Remove(_podloga.pKloc[i]);
                        }
                    System.Diagnostics.Debug.WriteLine("WYKRYTO KOLIZJA GORA");
                    this.Hitbox.Y = Hitbox.Y - (int)this.przyspieszenie.Y;
                    this.Wysok = 0;
                    this.przyspieszenie.Y = 0;
                    skok = true;
                    spadanie = false;

                    if (_podloga.pKloc[i].rodzaj == 2)
                    {
                        czydalej = true;
                        spadajacy = i;
                    }

                }
                else if (IntersectsFromRight(Hitbox, _podloga.pKloc[i].wymiary))
                {
                    if (_podloga.pKloc[i].rodzaj == 3)
                        if (this.Hitbox.Intersects(_podloga.pKloc[i].wymiary))
                        {
                            Star++;
                            _podloga.pKloc.Remove(_podloga.pKloc[i]);
                        }
                    System.Diagnostics.Debug.WriteLine("WYKRYTO KOLIZJA PRAWO");
                    this.Hitbox.X = Hitbox.X - (int)this.przyspieszenie.X;
                    this.Hitbox.Width = 24;
                    this.ruch_postaci = new Rectangle(3, 0, 12, 34);
                    
                    //    if ((int)this.przyspieszenie.X <= 0) this.przyspieszenie.X = 0;
                    //    this.Czas = 0;

                }
                else if (IntersectsFromLeft(Hitbox, _podloga.pKloc[i].wymiary))
                {
                    if (_podloga.pKloc[i].rodzaj == 3)
                        if (this.Hitbox.Intersects(_podloga.pKloc[i].wymiary))
                        {
                            Star++;
                            _podloga.pKloc.Remove(_podloga.pKloc[i]);
                        }
                    System.Diagnostics.Debug.WriteLine("WYKRYTO KOLIZJA LEWO");
                    this.Hitbox.X = Hitbox.X - (int)this.przyspieszenie.X;
                    this.Hitbox.Width = 24;

                }
                else if (IntersectsFromDown(Hitbox, _podloga.pKloc[i].wymiary))
                {
                    if (_podloga.pKloc[i].rodzaj == 3)
                        if (this.Hitbox.Intersects(_podloga.pKloc[i].wymiary))
                        {
                            Star++;
                            _podloga.pKloc.Remove(_podloga.pKloc[i]);
                        }
                    System.Diagnostics.Debug.WriteLine("WYKRYTO KOLIZJA DOL");
                    this.Hitbox.Y = Hitbox.Y + (int)this.przyspieszenie.Y;
                    this.przyspieszenie.Y = 0;
                    spadanie = true;
                    
                }
                
            }
            if (czydalej == true)
            {
                spadekKlocka = 5;
                for (int i = 0; i < _podloga.pKloc.Count; i++)
                {
                    if(spadajacy != i)
                    if (IntersectsFromTop(_podloga.pKloc[spadajacy].wymiary, _podloga.pKloc[i].wymiary))
                    {
                            
                            _podloga.pKloc[spadajacy].wymiary.Y = _podloga.pKloc[spadajacy].wymiary.Y - 5;
                        spadekKlocka = 0;
                        System.Diagnostics.Debug.WriteLine("COKOLWIEK");
                            if (_podloga.pKloc[spadajacy].rodzaj == 2) _podloga.pKloc.Remove(_podloga.pKloc[spadajacy]);

                    }
                }
                
            }

            if (shining < 0.49f)
            {
                shining += 0.005f;
            }
            if (shining >= 0.45f) isShine = false;
            if (isShine == false)
            {
                shining -= 0.009f;
            }
            if (shining <= 0) isShine = true;   
            
            System.Diagnostics.Debug.WriteLine(shining);

        }
        public void shine(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _podloga.pKloc.Count; i++)
            {
                if (_podloga.pKloc[i].rodzaj == 3)
                {
                    spriteBatch.Draw(Resources.lightMask, new Vector2(_podloga.pKloc[i].wymiary.X + 32, _podloga.pKloc[i].wymiary.Y + 32), null, Color.Yellow * 0.05f, 0, new Vector2(128, 128), 1f, SpriteEffects.None, 0);
                    spriteBatch.Draw(Resources.lightMask, new Vector2(_podloga.pKloc[i].wymiary.X + 32, _podloga.pKloc[i].wymiary.Y + 32), null, Color.Yellow * shining * 0.5f, 0, new Vector2(128, 128), 1f * (shining + 0.4f), SpriteEffects.None, 0);
                }
            }
           
        }
        public void shineMask(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _podloga.pKloc.Count; i++)
            {
                if (_podloga.pKloc[i].rodzaj == 3)
                    spriteBatch.Draw(Resources.lightMask, new Vector2(_podloga.pKloc[i].wymiary.X + 32, _podloga.pKloc[i].wymiary.Y + 32), null, Color.Black , 0, new Vector2(128, 128), 1f* (shining+0.4f), SpriteEffects.None, 0);

            }

        }

        public void Ruch(KeyboardState klawiatura)
        {


            if (klawiatura.IsKeyDown(Keys.A) && klawiatura.IsKeyDown(Keys.D))
            {
                this.przyspieszenie.X = 0;
                this.Czas = 0;
                this.Hitbox.Width = 28;
                this.ruch_postaci = new Rectangle(0, 36, 30, 27);


            }
            if (klawiatura.IsKeyDown(Keys.D) && poprzedniStan.IsKeyDown(Keys.D))
            {

                if (this.przyspieszenie.X <= 6) this.przyspieszenie.X += this.Speed * delta;
                
                    kierunek = SpriteEffects.None;
                this.Wysok = 0;
                this.Animacja();
                System.Diagnostics.Debug.WriteLine("Wcisnieto D");

            }
            if (klawiatura.IsKeyDown(Keys.A) && poprzedniStan.IsKeyDown(Keys.A))
            {
                if (this.przyspieszenie.X >= -6) this.przyspieszenie.X -= this.Speed * delta;
                this.Wysok = 0;
                kierunek = SpriteEffects.FlipHorizontally;
                
                this.Animacja();
                System.Diagnostics.Debug.WriteLine("Wcisnieto A");
            }


            if (klawiatura.IsKeyUp(Keys.F1) && poprzedniStan.IsKeyDown(Keys.F1))
            {
                devMod = !devMod;
                System.Diagnostics.Debug.WriteLine("Wcisnieto F1");

            }
            if (klawiatura.IsKeyUp(Keys.Escape) && poprzedniStan.IsKeyDown(Keys.Escape))
            {
                System.Diagnostics.Debug.WriteLine("Wcisnieto ESCAPE");
                Main.Akt_Stan = Main.Stan_Gry.Pauza;
                
            }

            if (klawiatura.IsKeyDown(Keys.W) && spadanie == false && skok == false)
            {
                skok = true;
                spadanie = true;
                this.Animacja();
                this.Wysok = 1;
                if (this.przyspieszenie.Y > -4)
                {
                    this.przyspieszenie.Y -= jumpVelocity * this.delta;
                }
                System.Diagnostics.Debug.WriteLine("Wcisnieto W");
            }

            if (klawiatura.IsKeyUp(Keys.A) && klawiatura.IsKeyUp(Keys.D))
            {

                if (this.Wysok == 0)
                {
                    this.ruch_postaci = new Rectangle(3, 0, 12, 34);
                    this.Hitbox.Width = 28;

                }
                this.Czas = 0;
                if (this.przyspieszenie.X > 0)
                {
                    this.przyspieszenie.X -= friction;
                }
                else if (this.przyspieszenie.X < 0)
                {
                    this.przyspieszenie.X += friction;
                }
                if (spadanie == true && (int)this.przyspieszenie.Y < 0)
                {
                    this.Wysok = 1;
                    Animacja();
                }

            }

            this.Hitbox.Y += (int)this.przyspieszenie.Y;
            this.Hitbox.X += (int)this.przyspieszenie.X;
            if (HP <= 0) Main.Akt_Stan = Main.Stan_Gry.Koniec;
            _podloga.pKloc[spadajacy].wymiary.Y += (int)this.spadekKlocka;
            poprzedniStan = Keyboard.GetState();
        }
        public void Draw_FLOOR(SpriteBatch spriteBatch)
        {
            _podloga.Draw(spriteBatch);
        }
        public void Draw(SpriteBatch spriteBatch, Kamera _kamera)
        {
            //_podloga.Draw(spriteBatch);
            spriteBatch.Draw(Resources.Postac, this.Hitbox, ruch_postaci, Color.White,0.0f,new Vector2(0,0),kierunek ,0.0f);

            //if (devMod == true) _kolizja.Draw(spriteBatch, Hitbox);

            //if (devMod == true)
            //{
            //    spriteBatch.DrawString(Resources.Czcionka, string.Format("KOORDYNATY X:{0}   Y:{1}", this.Hitbox.X, this.Hitbox.Y), new Vector2(this.Hitbox.X, this.Hitbox.Y), Color.White);
            //    spriteBatch.DrawString(Resources.Czcionka, string.Format("CZAS GRY:{0}", GTime), new Vector2(0, 25), Color.White);
            //    spriteBatch.DrawString(Resources.Czcionka, string.Format("PREDKOSC:{0}  GRAWITACJA:{1}", (int)this.przyspieszenie.X, (int)this.przyspieszenie.Y), new Vector2(this.Hitbox.X, this.Hitbox.Y+50), Color.White);
            //    spriteBatch.DrawString(Resources.Czcionka, string.Format("MYSZ X:{0}  MYSZ Y:{1}", MyszX, MyszY), new Vector2(0, 75), Color.White);
            //    spriteBatch.DrawString(Resources.Czcionka, string.Format("CAM X:{0}  CAM Y:{1}", _kamera.pozycja_kamera.X, _kamera.pozycja_kamera.Y), new Vector2(0, 100), Color.White);
            //    spriteBatch.DrawString(Resources.Czcionka, string.Format("MAP X:{0}  MAP Y:{1}", Resources.mapa.Height, Resources.mapa.Width), new Vector2(0, 125), Color.White);
            //}
            
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
