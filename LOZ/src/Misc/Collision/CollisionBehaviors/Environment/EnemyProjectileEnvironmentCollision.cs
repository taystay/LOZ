using LOZ.EnvironmentalClasses;
using LOZ.EnemyClass.Projectiles;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public static class EnemyProjectileEnvironmentCollision
    {
        public static void Handle(IGameObjects p, IGameObjects e, CollisionSide side)
        {
            DragonBreathe projectile = (DragonBreathe)p;
            IEnvironment environemnt = (IEnvironment)e;

            if (TypeC.Check(environemnt, typeof(InvisibleBlock)))
            {
                projectile.activeFire = false;
            }
        }
    }
}
