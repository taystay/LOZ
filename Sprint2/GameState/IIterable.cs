using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint2.GameState
{
    interface IIterable
    {
        public void SetToDefault();
        public void IterateForward();
        public void IterateReverse();
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
    }
}
