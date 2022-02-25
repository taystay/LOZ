using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace LOZ.Collision.Iterator
{
    interface IGameObjects
    {
        public Rectangle GetHitBox();
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
    }
}
