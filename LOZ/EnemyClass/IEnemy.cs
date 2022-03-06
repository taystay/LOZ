using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Collision;

namespace LOZ.EnemyClass
{
    public interface IEnemy : IGameObjects
    {
        public void KillItem();

        public bool IsActive();
   
    }
}
