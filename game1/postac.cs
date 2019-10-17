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
    public enum Direction
    {
        Up, Down, Left, Right
    };

    class Postac
    {
        Rectangle Hitbox;
        Direction Direction;    
        int Speed = 2;
        int Szer, Wysok,Czas,SzybAnimacji=10;
        bool Animowac;
        public Postac()
        {
            this.Hitbox = new Rectangle(0, 0, 51, 47);
            this.Szer = 4;
            this.Wysok = 1;
            this.Animowac = true;

        }
        public void Animacja()
        {
            this.Czas++;
            if (this.Czas == this.SzybAnimacji)
            {
                this.Czas = 0;
                if (this.Animowac)
                {
                    this.Szer++;
                    if (this.Szer > 4)
                    {
                        this.Szer = 1;
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
            if (klawiatura.IsKeyDown(Keys.Right))
            {
                this.Hitbox.X += this.Speed;
                this.Direction = Direction.Right;
                this.Animacja();
            }
            if (klawiatura.IsKeyDown(Keys.Left))
            {
                this.Hitbox.X -= this.Speed;
                this.Direction = Direction.Left;
                this.Animacja();


            }
            if (klawiatura.IsKeyDown(Keys.Down))
            {
                this.Hitbox.Y += this.Speed;
                this.Direction = Direction.Down;
                this.Animacja();


            }
            if (klawiatura.IsKeyDown(Keys.Up))
            {
                this.Hitbox.Y -= this.Speed;
                this.Direction = Direction.Up;
                this.Animacja();
                

            }
            if(klawiatura.IsKeyUp(Keys.Up) && klawiatura.IsKeyUp(Keys.Down) &&
                klawiatura.IsKeyUp(Keys.Left) && klawiatura.IsKeyUp(Keys.Right))
            {
                this.Wysok = 2;
                this.Czas = 0; 
            }
            switch (this.Direction)
            {
                case Direction.Up:
                    this.Wysok = 4;
                    break;
                case Direction.Down:
                    this.Wysok = 1;
                    break;
                case Direction.Left:
                    this.Wysok = 2;
                    break;
                case Direction.Right:
                    this.Wysok = 3;
                    break;
            }
            //RUCH BOHATERA
            //SPRAWDZENIE PRZYCISKÓW
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Resources.Postac, this.Hitbox,new Rectangle((this.Szer-1)*51, (this.Wysok-1)*47 ,51,47), Color.White);
            spriteBatch.End();
        }
    }
}
