﻿using Microsoft.Xna.Framework;
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
            public Vector2 velocity = new Vector2(-6, 0);
            public Int32 counter = 0;
            public static Texture2D normal_platform;
            public static Texture2D hazard_platform;
            public static Texture2D large_platform;
            public static string filename = "Images/platform";
            public static string hazard_filename = "Images/hazard_platform";
            public static string large_filename = "Images/large_platform";
            public bool landedOn = false;
            const float MOVE_SPEED = 0.05f;
            public static void LoadContent(ContentManager content)
            {
                normal_platform = content.Load<Texture2D>(filename);
                hazard_platform = content.Load<Texture2D>(hazard_filename);
                large_platform = content.Load<Texture2D>(large_filename);
            }
            public void draw(SpriteBatch spritebatch)
            {
                spritebatch.Draw(sprite, bounds, Color.White);
            }
            public void update(GamePadState g, KeyboardState k, Game1 game, GameTime gameTime)
            {
                bounds.Offset((Int32)(gameTime.ElapsedGameTime.Milliseconds * MOVE_SPEED * velocity.X), (Int32)velocity.Y);
            }
            public Platform(Vector2 position)
                : base(new Rectangle((int)position.X, (int)position.Y, normal_platform.Bounds.Width, normal_platform.Bounds.Height)) 
            {
                sprite = normal_platform;
            }
            public Platform(Int32 x, Int32 y)
                : base(x, y, normal_platform) 
            {        }
            public Platform(Int32 x, Int32 y, Texture2D tex)
                : base(x, y, tex)
            {        }
        }   
}
