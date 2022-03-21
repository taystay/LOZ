using LOZ.Collision;

namespace LOZ.EnemyClass.Projectiles
{
    interface IProjectile : IGameObjects
    {
        public bool IsActive(); //Projectiles should tell the user when they are done.*/   
    }
}
