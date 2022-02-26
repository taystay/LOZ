using LOZ.Collision;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.EnemyClass.Projectiles
{
    interface IProjectile : IGameObjects
    {
        public bool IsActive(); //Projectiles should tell the user when they are done.*/   
    }
}
