using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chased
{
    class Element : GameObject
    {
        public void LoadContent(ContentManager content) { }
        public void draw(SpriteBatch spriteBatch) { }
        public Element(Int32 x, Int32 y, Texture2D tex) 
            : base(x, y, tex) { }
    }
}
