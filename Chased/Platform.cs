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

        public class Platform : GameObject, Drawable
        {
            public Vector2 velocity = new Vector2(0, 0);
            public Int32 counter = 0;
            public static Texture2D sprite;
            public static string filename = "platform";
            public static void LoadContent(ContentManager content)
            {
                sprite = content.Load<Texture2D>(filename);
            }
            public void draw(SpriteBatch spritebatch)
            {
                spritebatch.Draw(sprite, bounds, Color.White);
            }
            public void update(GamePadState g, KeyboardState k, Game1 game, GameTime gameTime)
            {
                bounds.Offset((Int32)velocity.X, (Int32)velocity.Y);
            }
            public Platform(Vector2 position)
                : base(new Rectangle((int)position.X, (int)position.Y, sprite.Bounds.Width, sprite.Bounds.Height)) { velocity = new Vector2(-3, 0); }
            public Platform(Int32 x, Int32 y)
                : base(new Rectangle(x, y, sprite.Bounds.Width, sprite.Bounds.Height)) { velocity = new Vector2(-3, 0); }
        }
    
}
