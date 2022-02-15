
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.EnemyClass.Projectiles
{
    interface IProjectile
    {
        public bool IsActive(); //Projectiles should tell the user when they are done.*/
        public void Update(GameTime gameTime); //Update positions and stuff.
        public void Draw(SpriteBatch spriteBatch); //Draw where is needs to be.
    }
}
