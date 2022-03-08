using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Collision;

namespace LOZ.EnemyClass
{
    public interface IEnemy : IGameObjects
    {
        public int Health { get; set; }
        public void KillItem();
        public void TakeDamage(int damage);

        public bool IsActive();
   
    }
}
