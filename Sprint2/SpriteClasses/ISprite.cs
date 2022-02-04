using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public interface ISprite
    {
        public void SetSize(int size);
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch,  Point location);
    }
}
