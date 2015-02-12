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
    public class Player : GameObject, Drawable
    {
        public Vector2 velocity = new Vector2(0,0);
        public Int32 counter = 0;
        public static Texture2D sprite;
        public static string filename = "player";
        public GamePadState previousGamePadState;
        public KeyboardState previousKeyboardState;
        public enum fallState
        {
            grounded,
            jumping,
            falling
        }
        public fallState state = fallState.grounded;
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
            velocity.Y += 1;
            if(k.IsKeyDown(Keys.Space)) {
                if(state == fallState.grounded)
                {
                    state = fallState.jumping;   
                    velocity.Y = -20;
                }
                if(state == fallState.jumping)
                { 
                    counter += 1;
                }
                if (counter >= 20 && state == fallState.jumping)
                {
                    counter = 0;
                    state = fallState.falling;
                    velocity.Y = 0;
                }
            }
            else if( previousKeyboardState.IsKeyDown(Keys.Space) && state == fallState.jumping )
            {
                counter = 0;
                velocity.Y = 0;
                state = fallState.falling;
            }
            if(state == fallState.grounded)
            {
                state = fallState.falling;
            }
            
            Rectangle playerBottom = new Rectangle(bounds.X, bounds.Bottom - (Int32)velocity.Y - 1, bounds.Width, (Int32)velocity.Y + 1);
            foreach (Platform p in game.platforms)
            {
                if (p.bounds.Intersects(playerBottom) )
                {
                    this.bounds.Y = p.bounds.Y - this.bounds.Height;
                    this.velocity = new Vector2(0, 0);
                    this.state = fallState.grounded;
                }
            }
            bounds.Offset((Int32)velocity.X, (Int32)velocity.Y);

            if (bounds.Y > 1000)
            {
                bounds.Y = 0;
            }
            previousKeyboardState = k;
        }
        public Player(Vector2 position)
            : base(new Rectangle((int)position.X, (int)position.Y, sprite.Bounds.Width, sprite.Bounds.Height)) { }
        public Player(Int32 x, Int32 y)
            : base(new Rectangle(x, y, sprite.Bounds.Width, sprite.Bounds.Height)) { }
    }
}
