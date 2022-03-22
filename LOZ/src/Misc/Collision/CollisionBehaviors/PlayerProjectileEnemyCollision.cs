using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public static class PlayerProjectileEnemyCollision
    {
        public static void Handle(IGameObjects p, IGameObjects enemy, CollisionSide side)
        {
            IPlayerProjectile projectile = (IPlayerProjectile)p;
            AbstractEnemy _enemy = (AbstractEnemy)enemy;

            if (!TypeC.Check(enemy, typeof(SpikeTrap)))
            {
                _enemy.TakeDamage(projectile.Damage);

                if (side == CollisionSide.Top)
                    _enemy.KnockBack(new Point(0, -4));
                else if (side == CollisionSide.Bottom)
                    _enemy.KnockBack(new Point(0, 4));
                else if (side == CollisionSide.Left)
                    _enemy.KnockBack(new Point(-4, 0));
                else if (side == CollisionSide.Right)
                    _enemy.KnockBack(new Point(4, 0));
            }
        }
    }
}
