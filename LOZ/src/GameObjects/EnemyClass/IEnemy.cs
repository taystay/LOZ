using LOZ.Collision;
using Microsoft.Xna.Framework;

namespace LOZ.EnemyClass
{
    public interface IEnemy : IGameObjects
    {
        public int Health { get; set; }
        public void KillItem();
        public void TakeDamage(int damage);
        public void KnockBack(Point vel);
    }
}
