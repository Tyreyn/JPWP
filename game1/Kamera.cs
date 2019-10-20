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
        public Matrix Transform { get; private set; }

        public void Follow(Rectangle Position)
        {
            var position = Matrix.CreateTranslation(
              -Position.X - (51 / 2),
              -Position.Y - (47 / 2),
              0);

            var offset = Matrix.CreateTranslation(0,0,0);

            Transform = position * offset;
        }
    }
}
