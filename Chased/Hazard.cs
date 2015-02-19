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
    public class Hazard : Drawable
    {
        public List<Platform> platforms = new List<Platform>();
        public List<Element> hazards = new List<Element>();
        public List<Element> objectives = new List<Element>();
        public bool completed = false;
        public static void LoadContent(ContentManager content) { }
        public void draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.DrawString(Game1.font, "Hazard complete: " + completed, new Vector2(50, 50), Color.White);
        }
        public void update(GamePadState g, KeyboardState k, Game1 game, GameTime gameTime)
        {
            foreach(Platform p in platforms)
            {
                if(p.landedOn == false)
                {
                    return;
                }
            }
            completed = true;
        }
        public Hazard(Int32 minY, Int32 maxY, Game1 game)
        {
            create_step_hazard(minY, maxY, game);
        }
        public void create_step_hazard(Int32 minY, Int32 maxY, Game1 game)
        {
            Platform d = new Platform(2000 + 200, 500, Platform.hazard_platform);
            platforms.Add(d);
            game.platforms.Add(d);
            /*
            d = new Platform(500 + 300, 500, Platform.hazard_platform);
            platforms.Add(d);
            game.platforms.Add(d);
            */
            d = new Platform(2000 + 400, 300, Platform.hazard_platform);
            platforms.Add(d);
            game.platforms.Add(d);

            /*
            d = new Platform(500 + 500, 500, Platform.hazard_platform);
            platforms.Add(d);
            game.platforms.Add(d);
            */

            d = new Platform(2000 + 600, 500, Platform.hazard_platform);
            platforms.Add(d);
            game.platforms.Add(d);

        }
    }
}
