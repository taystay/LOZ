using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Collision;

namespace LOZ.EnemyClass
{
    interface IEnemy
    {
        //Nothing here just a separation between enemies and the rest of the game Objects

        public void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch, Point position);
    }
}
