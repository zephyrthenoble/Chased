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
    class GameObject : Drawable
    {
        Vector2 position;
        Texture2D sprite;
        Rectangle bounds;


        public GameObject(Vector2 position, Texture2D tex)
        {
            this.position = position;
            this.sprite = tex;
        }
        public GameObject(Int32 x, Int32 y, Texture2D tex)
        {
            this.position = new Vector2(x, y); 
            this.sprite = tex;
        }
        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(sprite, position);
        }
        private void updateBounds()
        {
            bounds = new Rectangle((int)position.X, (int)position.Y, sprite.Bounds.Width, sprite.Bounds.Height);
        }
    }
}
