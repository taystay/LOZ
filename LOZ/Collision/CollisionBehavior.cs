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
        private Rectangle collisionBox;
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
            firstBox = one.GetHitBox().ToRectangle();
            secondBox = two.GetHitBox().ToRectangle();
            _side = side;
            

            //LINK && ENVIORNMENT COLLISION
            if (IsType(one, typeof(ILink)) && IsType(two, typeof(IEnvironment)))
                HandleLinkEnviornment((ILink)one, (IEnvironment)two);

            //LINK && ENEMY COLLISION
            else if (IsType(one, typeof(ILink)) && IsType(two, typeof(IEnemy)))
                HandleLinkEnemy((ILink)one, (IEnemy)two);

            //ENEMY && ENVIORNMENT COLLISION
            else if (IsType(one, typeof(AbstractEnemy)) && IsType(two, typeof(IEnvironment)))
                HandleEnemyEnviornment((AbstractEnemy)one, (IEnvironment)two);

            //PLAYER PROJECTILE && ENEMY
            else if (IsType(one, typeof(IPlayerProjectile)) && IsType(two, typeof(AbstractEnemy)))
                HandleProjectileEnemy((IPlayerProjectile)one, (AbstractEnemy)two);

            //PLAYER PROJECTILE && LInk
            else if (IsType(one, typeof(ILink)) && IsType(two, typeof(IItem)))
                HandleLinkItem((ILink)one, (IItem)two);

            else if (IsType(one, typeof(ILink)) && IsType(two, typeof(IProjectile)))           
                HandleLinkProjectile((ILink)one, (IProjectile)two);
                

        }
        private void HandleLinkEnviornment(ILink link, IEnvironment block)
        {
            Point linkPos = link.Position;
            collisionBox = Rectangle.Intersect(firstBox, secondBox);
            //Make link not be able to move forward at all.
            if (_side == CollisionSide.Top)
                link.Position = new Point(linkPos.X, linkPos.Y - collisionBox.Height);          
            else if (_side == CollisionSide.Left)
                link.Position = new Point(linkPos.X - collisionBox.Width, linkPos.Y);           
            else if (_side == CollisionSide.Right)
                link.Position = new Point(linkPos.X + collisionBox.Width, linkPos.Y);      
            else if (_side == CollisionSide.Bottom)
                link.Position = new Point(linkPos.X, linkPos.Y + collisionBox.Height);

        }
        private void HandleLinkProjectile(ILink link, IProjectile proj)
        {
            
            TestingRoom.Instance.Link.TakeDamage();
        }


        private void HandleLinkEnemy(ILink link, IEnemy enemy)
        {
            
            TestingRoom.Instance.Link.TakeDamage();
        }

        private void HandleEnemyEnviornment(AbstractEnemy enemy, IEnvironment block)
        {
            Point enemyPos = enemy.Position;
            collisionBox = Rectangle.Intersect(firstBox, secondBox);
            //Make link not be able to move forward at all.
            if (_side == CollisionSide.Top)
                enemy.Position = new Point(enemyPos.X, enemyPos.Y - collisionBox.Height);
            else if (_side == CollisionSide.Left)
                enemy.Position = new Point(enemyPos.X - collisionBox.Width, enemyPos.Y);
            else if (_side == CollisionSide.Right)
                enemy.Position = new Point(enemyPos.X + collisionBox.Width, enemyPos.Y);
            else if (_side == CollisionSide.Bottom)
                enemy.Position = new Point(enemyPos.X, enemyPos.Y + collisionBox.Height);
        }

        private void HandleProjectileEnemy(IPlayerProjectile proj, AbstractEnemy enemy)
        {
            //Make enemy take damage or maybe disappear for the time being or even teleport back or move back
            enemy.KillItem();
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
