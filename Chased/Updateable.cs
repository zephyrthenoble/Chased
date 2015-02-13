using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chased
{
    interface Updateable
    {
        void update(GamePadState g, KeyboardState k, Game1 game, GameTime gameTime);
    }
}
