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
    public class Player : GameObject, Drawable, Updateable
    {
        public Vector2 velocity = new Vector2(0,0);
        public Int32 counter = 0;
        public const Int32 JUMP_HEIGHT = -20;
        public static string filename = "Images/player";
        public static Texture2D player_tex;
        public GamePadState previousGamePadState;
        public KeyboardState previousKeyboardState;
        public Rectangle playerBottom = new Rectangle(0, 0, 0, 0);
        public Rectangle playerTop = new Rectangle(0, 0, 0, 0);
        public enum fallState
        {
            grounded,
            jumping,
            falling
        }
        public fallState state = fallState.grounded;
        public static void LoadContent(ContentManager content)
        {
            player_tex = content.Load<Texture2D>(filename);
        }
        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(sprite, bounds, Color.White);
            spritebatch.Draw(Platform.hazard_platform, playerBottom, Color.Black);
            spritebatch.Draw(Platform.hazard_platform, playerTop, Color.Black);
        }
        public void manageInput(GamePadState g, KeyboardState k)
        {
            if(k.IsKeyDown(Keys.Space)) {
                if(state == fallState.grounded)
                {
                    state = fallState.jumping;   
                    velocity.Y = JUMP_HEIGHT;
                }
                if(state == fallState.jumping && velocity.Y >=0 )
                { 
                    state = fallState.falling;
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
            previousKeyboardState = k;
        }
        protected void offset()
        {
            bounds.Offset((Int32)velocity.X, (Int32)velocity.Y);
            playerBottom = new Rectangle(bounds.X, bounds.Bottom - (Int32)velocity.Y - 1, bounds.Width, (Int32)velocity.Y + 1);
            playerTop = new Rectangle(bounds.X, bounds.Y + (Int32)velocity.Y - 1, bounds.Width, -1*((Int32)velocity.Y + 1));
        }
        protected void manageIntersection(GameTime gameTime, Game1 game)
        {
            foreach (Platform p in game.platforms)
            {
                Rectangle platform_top = new Rectangle(p.bounds.X, p.bounds.Y, p.bounds.Width, 4);
                if (platform_top.Intersects(playerBottom) && state == fallState.falling)
                {
                    p.landedOn = true;
                    this.bounds.Y = p.bounds.Y - this.bounds.Height;
                    this.velocity = new Vector2(0, 0);
                    this.state = fallState.grounded;
                }
            }
            if (bounds.Y > 1000)
            {
                bounds.Y = 0;
            }
            else if (bounds.Y < -50)
            {
                bounds.Y = 800;
            }
        }
        public void update(GamePadState g, KeyboardState k, Game1 game, GameTime gameTime)
        {
            velocity.Y += 1;
            manageInput(g, k);
            offset();
            manageIntersection(gameTime, game);
        }
        public Player(Vector2 position)
            : base(new Rectangle((int)position.X, (int)position.Y, player_tex.Bounds.Width, player_tex.Bounds.Height)) { sprite = player_tex; }
        public Player(Int32 x, Int32 y)
            : base(new Rectangle(x, y, player_tex.Bounds.Width, player_tex.Bounds.Height)) { sprite = player_tex; }
    }
}
