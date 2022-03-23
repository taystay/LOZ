using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Hud
{
    interface HudElement
    {
        public void Update();

        public void Draw(SpriteBatch spriteBatch);
    }
}
