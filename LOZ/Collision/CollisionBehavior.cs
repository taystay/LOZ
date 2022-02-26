using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.LinkClasses;
using LOZ.EnvironmentalClasses;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;
namespace LOZ.Collision.Iterator
{
    class CollisionBehavior
    {
        private Rectangle firstBox;
        private Rectangle secondBox;
        private CollisionSide _side;
        public CollisionBehavior()
        {

        }
        public void HandleCollision(IGameObjects one, IGameObjects two, CollisionSide side)
        {
            firstBox = one.GetHitBox();
            secondBox = two.GetHitBox();
            _side = side;

            //LINK && ENVIORNMENT COLLISION
            if (one.GetType().IsAssignableFrom(typeof(ILink)) && two.GetType().IsAssignableFrom(typeof(IEnvironment)))
                HandleLinkEnviornment((ILink)one, (IEnvironment)two);

            //LINK && ENEMY COLLISION
            else if (one.GetType().IsAssignableFrom(typeof(ILink)) && two.GetType().IsAssignableFrom(typeof(IEnemy)))
                HandleLinkEnemy((ILink)one, (IEnemy)two);

            //ENEMY && ENVIORNMENT COLLISION
            else if (one.GetType().IsAssignableFrom(typeof(IEnemy)) && two.GetType().IsAssignableFrom(typeof(IEnvironment)))
                HandleEnemyEnviornment((IEnemy)one, (IEnvironment)two);

            //PLAYER PROJECTILE && ENEMY
            else if (one.GetType().IsAssignableFrom(typeof(IPlayerProjectile)) && two.GetType().IsAssignableFrom(typeof(IEnemy)))
                HandleProjectileEnemy((IPlayerProjectile)one, (IEnemy)two);

        }
        private void HandleLinkEnviornment(ILink link, IEnvironment block)
        {
            /*
            if(_side == CollisionSide.Bottom)
                link.Position = new Point(firstBox.X - firstBox.Width / 2, firstBox.Y)
            */
        }

        private void HandleLinkEnemy(ILink link, IEnemy enemy)
        {

        }

        private void HandleEnemyEnviornment(IEnemy enemy, IEnvironment block)
        {

        }

        private void HandleProjectileEnemy(IPlayerProjectile link, IEnemy enemy)
        {

        }
    }
}
