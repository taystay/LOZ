using Microsoft.Xna.Framework;
using LOZ.EnemyClass;
using LOZ.GameState;

namespace LOZ.Collision
{
    public static class DoorColliderEnemyCollision
    {
        public static void Handle(IGameObjects blockObj, IGameObjects enemyObj, CollisionSide side)
        {
            AbstractEnemy enemy = (AbstractEnemy)enemyObj;
            Rectangle enemyBox = enemyObj.GetHitBox().ToRectangle();
            Rectangle blockBox = blockObj.GetHitBox().ToRectangle();

            Point linkPos = enemy.Position;
            Rectangle collisionBox = Rectangle.Intersect(enemyBox, blockBox);

            //Make link not be able to move forward at all.
            if (side == CollisionSide.Top)
                enemy.Position = new Point(blockBox.X - blockBox.Width / 2, blockBox.Y - collisionBox.Height - blockBox.Height / 2);
            else if (side == CollisionSide.Left)
                enemy.Position = new Point(linkPos.X - collisionBox.Width - blockBox.Width / 2, linkPos.Y - blockBox.Height / 2);
            else if (side == CollisionSide.Right)
                enemy.Position = new Point(linkPos.X + collisionBox.Width - blockBox.Width / 2, linkPos.Y - blockBox.Height / 2);
            else if (side == CollisionSide.Bottom)
                enemy.Position = new Point(linkPos.X - blockBox.Width / 2, linkPos.Y + collisionBox.Height - blockBox.Height / 2);
        }
    }
}
