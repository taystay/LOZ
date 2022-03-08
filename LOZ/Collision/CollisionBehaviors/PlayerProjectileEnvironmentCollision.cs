using LOZ.EnemyClass;
using LOZ.EnemyClass.Projectiles;
using LOZ.ItemsClasses;

namespace LOZ.Collision
{
    public static class PlayerProjectileEnemyCollision
    {
        public static void Handle(IGameObjects p, IGameObjects enemy)
        {
            IPlayerProjectile projectile = (IPlayerProjectile)p;
            IEnemy _enemy = (IEnemy)enemy;
            if(!TypeC.Check(enemy, typeof(SpikeTrap)))
                _enemy.TakeDamage(projectile.Damage);

        }
    }
}
