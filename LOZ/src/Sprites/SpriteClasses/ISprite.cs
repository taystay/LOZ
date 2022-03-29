using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses
{
    public interface ISprite
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch,  Point location);
        public void ChangeScale(double scale);

        public void Draw(SpriteBatch spriteBatch, Point location, Color c);
    }
}
