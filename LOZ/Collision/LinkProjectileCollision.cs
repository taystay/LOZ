using LOZ.EnemyClass.Projectiles;
using LOZ.GameState;

namespace LOZ.Collision
{
    public static class LinkProjectileCollision
    {
        public static void Handle(IGameObjects p)
        {
            IProjectile projectile = (IProjectile)p;
            TestingRoom.Instance.Link.TakeDamage();
        }
    }
}
