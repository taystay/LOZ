using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    interface IItem
    {
        public void SetSpriteActivity(Boolean activity);
        public Boolean SpriteActive();
        public void Update();

        public void Draw(SpriteBatch spriteBatch);

    }
}
