using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.EnvironmentalClasses
{
    public interface IEnvironment
    {
        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);
    }
}
