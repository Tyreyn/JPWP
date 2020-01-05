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
    /// <summary>
    /// Gra numer 1
    /// </summary>
    class Main
    {
        public enum Stan_Gry
        {
            Menu,
            Gra,
            Pauza,
            Koniec,
            Wyjscie
        }
        /// <summary>
        /// wczytanie menu końcowego okna
        /// </summary>
        Menu_Koniec menu_Koniec;
        /// <summary>
        /// wczytanie mapy
        /// </summary>
        Mapa mapa1;
        /// <summary>
        /// wczytanie postaci
        /// </summary>
        Postac akt_postac;
        /// <summary>
        /// wczytanie kamery
        /// </summary>
        Kamera _kamera;
        /// <summary>
        /// wczytanie menu
        /// </summary>
        Menu _menu;
        /// <summary>
        /// wczytanie podłogi
        /// </summary>
        Podloga _podloga;
        /// <summary>
        /// wczytanie menu pauzy
        /// </summary>
        Menu_Pauza menu_Pauza;
        /// <summary>
        /// wczytanie cieni
        /// </summary>
        public static RenderTarget2D darkness;
        /// <summary>
        /// wczytanie głownego okna
        /// </summary>
        public static RenderTarget2D mainTarget;
        /// <summary>
        /// wczytanie stanu gry
        /// </summary>
        public static Stan_Gry Akt_Stan = 0;
        /// <summary>
        /// wczytanie zasobów programu numer 1
        /// </summary>
        public Main(GraphicsDevice graphicsDevice)
        {
            menu_Koniec = new Menu_Koniec(graphicsDevice);
            menu_Pauza = new Menu_Pauza(graphicsDevice);
            _menu = new Menu(graphicsDevice);
            _kamera = new Kamera(graphicsDevice);
            akt_postac = new Postac(graphicsDevice);
            mapa1 = new Mapa(graphicsDevice);
            _podloga = new Podloga(graphicsDevice);
            _podloga.wczytaj();
            darkness = new RenderTarget2D(graphicsDevice, Mapa.mapa_1.GetLength(1) * 64, Mapa.mapa_1.GetLength(0) * 64);
            mainTarget = new RenderTarget2D(graphicsDevice, Mapa.mapa_1.GetLength(1) * 64, Mapa.mapa_1.GetLength(0) * 64);


        }

        /// <summary>
        /// Odświeżanie
        /// </summary>
        /// <param name="mysz">zczytywanie ruchu myszki</param>
        /// <param name="klawiatura">zczytywanie klawiatury</param>
        /// <param name="gameTime">czas gry</param>
        public void Update(MouseState mysz, KeyboardState klawiatura, GameTime gameTime)
        {
            Akt_Stan = _menu.Stan_Gry(Akt_Stan);
            switch (Akt_Stan)
            {
                case Stan_Gry.Gra:
                    akt_postac.Update(mysz, klawiatura, gameTime);
                    _kamera.Update(gameTime, akt_postac);
                    break;
                case Stan_Gry.Menu:
                    _menu.Update(gameTime, mysz);
                    break;
                case Stan_Gry.Pauza:
                    menu_Pauza.Update(gameTime, mysz);
                    menu_Pauza.Stan_Gry();
                    break;
                case Stan_Gry.Koniec:
                    menu_Koniec.Update(gameTime, mysz);
                    menu_Koniec.Stan_Gry();
                    break;

            }



        }

        /// <summary>
        /// rysowanie głównego programu numer 1
        /// </summary>
        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            switch (Akt_Stan)
            {
                case Stan_Gry.Menu:
                    _menu.Draw(spriteBatch);
                    break;
                case Stan_Gry.Gra:
                    graphicsDevice.SetRenderTarget(darkness);
                    graphicsDevice.Clear(Color.Black);
                    var blend = new BlendState
                    {
                        AlphaSourceBlend = Blend.Zero,
                        AlphaDestinationBlend = Blend.InverseSourceColor,
                        ColorSourceBlend = Blend.Zero,
                        ColorDestinationBlend = Blend.InverseSourceColor,
                    };

                    spriteBatch.Begin(SpriteSortMode.Immediate, blendState: blend);
                    akt_postac.shineMask(spriteBatch);

                    spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X + 64, akt_postac.Hitbox.Y), null, Color.Black * 0.3f, 0, new Vector2(128, 128), 20f, SpriteEffects.None, 0);
                    spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X + 64, akt_postac.Hitbox.Y), null, Color.Black * 0.25f, 0, new Vector2(128, 128), 3f, SpriteEffects.None, 0);
                    spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X + 64, akt_postac.Hitbox.Y), null, Color.Black * 0.5f, 0, new Vector2(128, 128), 1f, SpriteEffects.None, 0);
                    spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X + 64, akt_postac.Hitbox.Y), null, Color.Black * 0.7f, 0, new Vector2(128, 128), 0.8f, SpriteEffects.None, 0);
                    spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X + 64, akt_postac.Hitbox.Y), null, Color.Black * 0.85f, 0, new Vector2(128, 128), 0.1f, SpriteEffects.None, 0);


                    spriteBatch.End();

                    graphicsDevice.SetRenderTarget(null);
                    graphicsDevice.Clear(Color.Black);
                    graphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
                    spriteBatch.Begin(transformMatrix: _kamera.transformGracz);
                    spriteBatch.Draw(Resources.las, new Rectangle(0, 0, 1440, 1860), Color.White);
                    akt_postac.Draw_FLOOR(spriteBatch);
                    spriteBatch.Draw(darkness, Vector2.Zero, Color.Black);
                    spriteBatch.End();

                    spriteBatch.Begin(transformMatrix: _kamera.transformGracz);
                    akt_postac.shine(spriteBatch);

                    spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X + 64, akt_postac.Hitbox.Y), null, Color.Red * 0.1f, 0, new Vector2(128, 128), 1.5f, SpriteEffects.None, 0);
                    spriteBatch.Draw(Resources.lightMask, new Vector2(akt_postac.Hitbox.X + 64, akt_postac.Hitbox.Y), null, Color.Red * 0.05f, 0, new Vector2(128, 128), 0.75f, SpriteEffects.None, 0);
                    akt_postac.Draw(spriteBatch, _kamera);

                    spriteBatch.End();
                    spriteBatch.Begin();
                    if (Postac.HP == 3)
                    {
                        spriteBatch.Draw(Resources.HP3, new Rectangle(0, 0, 300, 150), new Rectangle(0, 0, 542, 200), Color.White);
                    }
                    else if (Postac.HP == 2)
                    {
                        spriteBatch.Draw(Resources.HP2, new Rectangle(0, 0, 300, 150), new Rectangle(0, 0, 542, 200), Color.White);

                    }
                    else if (Postac.HP == 1)
                    {
                        spriteBatch.Draw(Resources.HP1, new Rectangle(0, 0, 300, 150), new Rectangle(0, 0, 542, 200), Color.White);

                    }
                    if (Postac.Star == 0)
                    {
                        spriteBatch.Draw(Resources.NULL, new Rectangle(980, 0, 300, 150), new Rectangle(0, 0, 542, 200), Color.White);
                    }
                    else if (Postac.Star == 1)
                    {
                        spriteBatch.Draw(Resources.ONE, new Rectangle(980, 0, 300, 150), new Rectangle(0, 0, 542, 200), Color.White);

                    }
                    else if (Postac.Star == 2)
                    {
                        spriteBatch.Draw(Resources.TWO, new Rectangle(980, 0, 300, 150), new Rectangle(0, 0, 542, 200), Color.White);

                    }
                    else if (Postac.Star == 3)
                    {
                        spriteBatch.Draw(Resources.THREE, new Rectangle(980, 0, 300, 150), new Rectangle(0, 0, 542, 200), Color.White);

                    }
                    spriteBatch.End();

                    break;
                case Stan_Gry.Pauza:
                    menu_Pauza.Draw(spriteBatch);
                    break;
                case Stan_Gry.Koniec:
                    menu_Koniec.Draw(spriteBatch);
                    break;

                case Stan_Gry.Wyjscie:
                    Game1.self.Exit();
                    break;

            }

        }

    }
}
