using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.LinkClasses;
using LOZ.EnvironmentalClasses;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;

namespace LOZ.Collision
{
    class CollisionBehavior
    {
        private Rectangle firstBox;
        private Rectangle secondBox;
        private CollisionSide _side;
        public CollisionBehavior()
        {

        }
        private bool IsType(object o, System.Type t)
        {
            if (o.GetType().IsAssignableFrom(t)) return true;
            System.Type[] interfaces = o.GetType().GetInterfaces();
            foreach (System.Type type in interfaces)
            {
                if (type == t) return true;
            }
            return false;
        }
        public void HandleCollision(IGameObjects one, IGameObjects two, CollisionSide side)
        {
            firstBox = one.GetHitBox();
            secondBox = two.GetHitBox();
            _side = side;

            //LINK && ENVIORNMENT COLLISION
            if (IsType(one, typeof(ILink)) && IsType(one, typeof(IEnvironment)))
                HandleLinkEnviornment((ILink)one, (IEnvironment)two);

            //LINK && ENEMY COLLISION
            else if (IsType(one, typeof(ILink)) && IsType(one, typeof(IEnemy)))
                HandleLinkEnemy((ILink)one, (IEnemy)two);

            //ENEMY && ENVIORNMENT COLLISION
            else if (IsType(one, typeof(IEnemy)) && IsType(one, typeof(IEnvironment)))
                HandleEnemyEnviornment((IEnemy)one, (IEnvironment)two);

            //PLAYER PROJECTILE && ENEMY
            else if (IsType(one, typeof(IPlayerProjectile)) && IsType(one, typeof(IEnemy)))
                HandleProjectileEnemy((IPlayerProjectile)one, (IEnemy)two);

            //PLAYER PROJECTILE && ENEMY
            else if (IsType(one, typeof(ILink)) && IsType(one, typeof(IItem)))
                HandleLinkItem((ILink)one, (IItem)two);

        }
        private void HandleLinkEnviornment(ILink link, IEnvironment block)
        {
            //Make link not be able to move forward at all.
        }

        private void HandleLinkEnemy(ILink link, IEnemy enemy)
        {
            //Make link turn pink or take damage lmao.
        }

        private void HandleEnemyEnviornment(IEnemy enemy, IEnvironment block)
        {
            //Make enemy not be able to move forward when walking into a wall
        }

        private void HandleProjectileEnemy(IPlayerProjectile link, IEnemy enemy)
        {
            //Make enemy take damage or maybe disappear for the time being or even teleport back or move back
        }

        private void HandleLinkItem(ILink link, IItem item)
        {
            //Make item disappear *poof*
        }
    }
}
