using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public interface IGameObjects
    {
        public Hitbox GetHitBox();        
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        public void Draw(SpriteBatch spriteBatch, Point offset);
    }
}
