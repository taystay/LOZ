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
        public void SetSize(double size);
        public void SetPosition(Point position);
        public Boolean SpriteActive();
        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);

    }
}
