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
        public enum type
        {
            hoop,
            lava
        }
        public static Texture2D hoop;
        public static Texture2D lava;
        type myType;
        public static void LoadContent(ContentManager content) { }
        public void draw(SpriteBatch spriteBatch) { }
        public Element(Int32 x, Int32 y, Texture2D tex, type t) 
            : base(x, y, tex) 
        {
            myType = t;
        }
    }
}
