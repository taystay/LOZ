
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.EnemyClass
{
    interface IEnemy
    {
        public void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch);

    }
}
