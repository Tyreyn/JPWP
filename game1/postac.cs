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
        Up, Down, Left, Right
    };

    class Postac
    {
        public Rectangle Hitbox;
        Direction Direction;    
        int Speed = 1;
        int Poslizg = 0;
        int Szer, Wysok,Czas,SzybAnimacji=7;
        int MyszX, MyszY;
        bool Animowac;
        int GTime;
        int GRAWITACJA = 1;
        bool devMod = false;
        Kolizja _kolizja;
        public Postac(GraphicsDevice graphicsDevice)
        {
            _kolizja = new Kolizja(Resources.Postac,graphicsDevice);
            this.Hitbox = new Rectangle(0, 0, 51, 47);
            this.Szer = 4;
            this.Wysok = 1;
            this.Animowac = true;

        }
        public void Animacja()
        {
            
            this.Czas++;
            
            if (this.Czas == this.SzybAnimacji && Math.Abs(this.Poslizg) >= 0)
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
        public void Update(MouseState mysz, KeyboardState klawiatura)
        {
            
            MyszX = mysz.Position.X;
            MyszY = mysz.Position.Y;
            if (klawiatura.IsKeyDown(Keys.Left) && klawiatura.IsKeyDown(Keys.Right))
            {
                this.Poslizg = 0;
                this.Wysok = 1;
            } else if (klawiatura.IsKeyDown(Keys.Right))
            {
                if (this.Poslizg <= 2) this.Poslizg += this.Speed;
                this.Direction = Direction.Right;
                this.Animacja();

            } else if (klawiatura.IsKeyDown(Keys.Left))
            {
                if (this.Poslizg >= -2) this.Poslizg -= this.Speed;
                this.Direction = Direction.Left;
                this.Animacja();
            }
            if (klawiatura.IsKeyDown(Keys.F1))
            {
                devMod = !devMod;
            }



            if (klawiatura.IsKeyUp(Keys.Left) && klawiatura.IsKeyUp(Keys.Right))
            {
                this.Szer = 1;
                this.Wysok = 1;
                this.Czas = 0;
                if (this.Poslizg > 0)
                {
                    this.Poslizg -= 1;
                } else if (this.Poslizg < 0)
                {
                    this.Poslizg += 1;
                }

                }
                if (this.Poslizg > 0)
                {
                    this.Wysok = 3;
                } else if (this.Poslizg < 0)
                {
                    this.Wysok = 2;
            }
            
            GTime++;
            this.Hitbox.X += (int)this.Poslizg;
            this.Hitbox.Y += GRAWITACJA;
        }
        //ZCZYTYWANIE KLAWIATURY
        //RUCH BOHATERA
        //SPRAWDZENIE PRZYCISKÓW
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Resources.Postac, this.Hitbox,new Rectangle((this.Szer-1)*51, (this.Wysok-1)*47 ,51,47), Color.White);
            if(devMod == true)_kolizja.Draw(spriteBatch, Hitbox);
            spriteBatch.End();
            spriteBatch.Begin();
            if (devMod == true)
            {
                spriteBatch.DrawString(Resources.Czcionka, string.Format("KOORDYNATY X:{0}   Y:{1}", this.Hitbox.X, this.Hitbox.Y), new Vector2(0, 0), Color.Black);
                spriteBatch.DrawString(Resources.Czcionka, string.Format("CZAS GRY:{0}", GTime), new Vector2(0, 25), Color.Black);
                spriteBatch.DrawString(Resources.Czcionka, string.Format("PREDKOSC:{0}  GRAWITACJA:{1}", this.Poslizg, GRAWITACJA), new Vector2(0, 50), Color.Black);
                spriteBatch.DrawString(Resources.Czcionka, string.Format("MYSZ X:{0}  MYSZ Y:{1}", MyszX, MyszY), new Vector2(0, 75), Color.Black);


               
            }
            spriteBatch.End();

        }
        
    }
}
