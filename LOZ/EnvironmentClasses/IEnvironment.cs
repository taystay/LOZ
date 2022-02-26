using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.EnvironmentalClasses
{
    public interface IEnvironment
    {
        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);
    }
}
