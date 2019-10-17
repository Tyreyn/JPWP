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
        public static Texture2D Postac;

        public static void LoadContent(ContentManager Content)
        {
            Postac = Content.Load<Texture2D>("crowley_wings");
        }

    }
}
