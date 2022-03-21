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
            int knockback = 40;

            if (!TypeC.Check(enemy, typeof(SpikeTrap)))
            {
                if(!_enemy.IsDamaged)
                {
                    if (side == CollisionSide.Top)
                        _enemy.Position = new Point(_enemy.Position.X, _enemy.Position.Y - knockback);
                    else if (side == CollisionSide.Left)
                        _enemy.Position = new Point(_enemy.Position.X - knockback, _enemy.Position.Y);
                    else if (side == CollisionSide.Right)
                        _enemy.Position = new Point(_enemy.Position.X + knockback, _enemy.Position.Y);
                    else if (side == CollisionSide.Bottom)
                        _enemy.Position = new Point(_enemy.Position.X, _enemy.Position.Y + knockback);
                }

                _enemy.TakeDamage(projectile.Damage);
            }
        }
    }
}
