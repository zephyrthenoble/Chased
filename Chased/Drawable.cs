using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chased
{
    interface Drawable
    {
        void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spritebatch);
    }
}