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
    public class GameObject
    {
        public Rectangle bounds;
        public Texture2D sprite;
        public GameObject(Int32 x, Int32 y, Texture2D tex)
        {
            sprite = tex;
            this.bounds = new Rectangle(x, y, sprite.Width, sprite.Height);
        }
        public GameObject(Rectangle bounds)
        {
            this.bounds = bounds;
        }
        public GameObject(Int32 x, Int32 y, Int32 width, Int32 height)
        {
            this.bounds = new Rectangle(x, y, width, height);
        }
    }
}
