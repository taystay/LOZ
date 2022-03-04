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
            Rectangle projectileBox = projectile.GetHitBox().ToRectangle();
            Rectangle blockBox = block.GetHitBox().ToRectangle();

            Rectangle collisionBox = Rectangle.Intersect(projectileBox, blockBox);
            if (!Type.Check(projectile, typeof(Bomb)) && !Type.Check(projectile, typeof(FireProjectile)))
                projectile.KillItem();
        }
    }
}
