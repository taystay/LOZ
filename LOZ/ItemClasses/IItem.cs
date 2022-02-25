using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.ItemsClasses
{

    public enum Direction
    {
        Up, 
        Left,
        Right,
        Down
    };

    public interface IItem
    {
        public Boolean SpriteActive();

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);

    }
}
