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
    class Main
    {
        Postac akt_postac;
        public Main()
        {
            akt_postac = new Postac();
        }
        public void Update(MouseState mysz,KeyboardState klawiatura)
        {
            akt_postac.Update(mysz,klawiatura);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            akt_postac.Draw(spriteBatch);
        }
    }
}
