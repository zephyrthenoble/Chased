using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chased
{
    public class Element : GameObject, Drawable, Updateable
    {
        public enum type
        {
            hoop,
            lava
        }
        public static Texture2D hoop;
        public static Texture2D lava;
        type myType;
        public void update(GamePadState g, KeyboardState k, Game1 game, GameTime gameTime)
        {

        }
        public static void LoadContent(ContentManager content) { }
        public void draw(SpriteBatch spriteBatch) { }
        public Element(Int32 x, Int32 y, Texture2D tex, type t) 
            : base(x, y, tex) 
        {
            myType = t;
        }
    }
}
