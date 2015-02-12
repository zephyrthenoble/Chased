using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chased
{
    class Hazard : Drawable
    {
        public List<Platform> platforms;
        public List<Platform> hazards;
        public void LoadContent(ContentManager content) { }
        public void draw(SpriteBatch spriteBatch) { }
        public Hazard(Int32 minY, Int32 maxY)
        {

        }
    }
}
