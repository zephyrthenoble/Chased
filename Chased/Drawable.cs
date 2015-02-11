using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chased
{
    interface Drawable
    {
        void loadDrawables(Microsoft.Xna.Framework.Content.ContentManager content);
        void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spritebatch);
    }
}