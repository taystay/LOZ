using Microsoft.Xna.Framework;
using LOZ.EnemyClass;
using LOZ.EnvironmentalClasses;

namespace LOZ.Collision
{
    public static class EnemyEnviornmentCollision
    {
        public static void Handle(IGameObjects enemyObj, IGameObjects blockObj, CollisionSide side)
        {
            AbstractEnemy enemy = (AbstractEnemy)enemyObj;
            IEnvironment block = (IEnvironment)blockObj;
            Rectangle enemyBox = enemyObj.GetHitBox().ToRectangle();
            Rectangle blockBox = blockObj.GetHitBox().ToRectangle();

            Point linkPos = enemy.Position;
            Rectangle collisionBox = Rectangle.Intersect(enemyBox, blockBox);

            if (!TypeC.CheckPair(enemy, typeof(Bat), block, typeof(BasementBlock)) || TypeC.Check(block, typeof(InvisibleBlock)))
            {
                if (side == CollisionSide.Top)
                    enemy.Position = new Point(linkPos.X, linkPos.Y - collisionBox.Height);
                else if (side == CollisionSide.Left)
                    enemy.Position = new Point(linkPos.X - collisionBox.Width, linkPos.Y);
                else if (side == CollisionSide.Right)
                    enemy.Position = new Point(linkPos.X + collisionBox.Width, linkPos.Y);
                else if (side == CollisionSide.Bottom)
                    enemy.Position = new Point(linkPos.X, linkPos.Y + collisionBox.Height);
            }
        }
    }
}
