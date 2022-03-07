using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public static class PlayerProjectileEnvironmentCollision
    {
        public static void Handle(IGameObjects p, IGameObjects block)
        {
            IPlayerProjectile projectile = (IPlayerProjectile)p;

            if (!TypeC.Check(projectile, typeof(Bomb)) && !TypeC.Check(projectile, typeof(FireProjectile)))
                projectile.KillItem();
        }
    }
}
