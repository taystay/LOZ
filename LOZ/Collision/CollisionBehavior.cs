using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.LinkClasses;
using LOZ.EnvironmentalClasses;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using System.Diagnostics;
using LOZ.EnemyClass.Projectiles;
using LOZ.GameState;

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
        private bool IsType(object object_o, System.Type comparisonType)
        {
            System.Type actualType = object_o.GetType();
            if (actualType.IsAssignableFrom(comparisonType)) return true;
            if (actualType.IsSubclassOf(comparisonType)) return  true;

            System.Type[] interfaces = actualType.GetInterfaces();
            foreach (System.Type type in interfaces)
            {               
                if (type == comparisonType) return  true;
            }
            return false;
        }
        public void HandleCollision(IGameObjects one, IGameObjects two, CollisionSide side)
        {
            firstBox = one.GetHitBox();
            secondBox = two.GetHitBox();
            _side = side;

            //LINK && ENVIORNMENT COLLISION
            if (IsType(one, typeof(ILink)) && IsType(two, typeof(IEnvironment)))
                HandleLinkEnviornment((ILink)one, (IEnvironment)two);

            //LINK && ENEMY COLLISION
            else if (IsType(one, typeof(ILink)) && IsType(two, typeof(IEnemy)))
                HandleLinkEnemy((ILink)one, (IEnemy)two);

            //ENEMY && ENVIORNMENT COLLISION
            else if (IsType(one, typeof(IEnemy)) && IsType(two, typeof(IEnvironment)))
                HandleEnemyEnviornment((IEnemy)one, (IEnvironment)two);

            //PLAYER PROJECTILE && ENEMY
            else if (IsType(one, typeof(IPlayerProjectile)) && IsType(two, typeof(IEnemy)))
                HandleProjectileEnemy((IPlayerProjectile)one, (IEnemy)two);

            //PLAYER PROJECTILE && LInk
            else if (IsType(one, typeof(ILink)) && IsType(two, typeof(IItem)))
                HandleLinkItem((ILink)one, (IItem)two);

            else if (IsType(one, typeof(ILink)) && IsType(two, typeof(IProjectile)))           
                HandleLinkProjectile((ILink)one, (IProjectile)two);
                

        }
        private void HandleLinkEnviornment(ILink link, IEnvironment block)
        {
            //Make link not be able to move forward at all.
        }
        private void HandleLinkProjectile(ILink link, IProjectile proj)
        {
            
            TestingRoom.Instance.Link.TakeDamage();
        }


        private void HandleLinkEnemy(ILink link, IEnemy enemy)
        {
            
            TestingRoom.Instance.Link.TakeDamage();
        }

        private void HandleEnemyEnviornment(IEnemy enemy, IEnvironment block)
        {
            //Make enemy not be able to move forward when walking into a wall
            //only way to do this right is by testing.
            //Rectangle enemRec = enemy.GetHitBox();
            //Rectangle blockRec = block.GetHitBox();
            //dx = enemyRec.X - blockRec.X
            //dy = enemyRec.Y - blockRec.Y
            //IF(SIDE == DOWN)
            //enemy.position = new Point(enemyRec.X, enemyRec.Y - dy)

            //ROUGHLY something like that.
        }

        private void HandleProjectileEnemy(IPlayerProjectile link, IEnemy enemy)
        {
            //Make enemy take damage or maybe disappear for the time being or even teleport back or move back
        }

        private void HandleLinkItem(ILink link, IItem item)
        {
            //Make item disappear *poof*
            if (!IsType(item, typeof(IPlayerProjectile)))
            {
                item.KillItem();

            }

        }
    }
}
