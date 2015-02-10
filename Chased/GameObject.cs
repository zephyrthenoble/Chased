//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Chased
{
    class Point
    {
        Int32 x;
        Int32 y;
        public Point(Int32 x, Int32 y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class GameObject : Drawable
    {
        Point position;
        Texture2D texture;
        String file = "test.png";
        public GameObject(Point position)
        {
            this.position = position;
        }
        public GameObject(Int32 x, Int32 y)
        {
            this.position = new Point(x, y);
        }
        public void loadDrawables(ContentManager content)
        {
            texture = content.Load<Texture2D>(file);
        }
        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture);
        }
    }
}
