using Microsoft.Xna.Framework;
using LOZ.LinkClasses;
using LOZ.EnvironmentalClasses;

namespace LOZ.Collision
{
    public static class BlockBlockCollision
    {
        public static void Handle(IGameObjects blockObj1, IGameObjects blockObj2, CollisionSide side)
        {
            IEnvironment block1 = (IEnvironment)blockObj1;
            IEnvironment block2 = (IEnvironment)blockObj2;
            Point blockPos1 = block1.Position;
            Point blockPos2 = block2.Position;
            Rectangle linkBox = block1.GetHitBox().ToRectangle();
            Rectangle blockBox = block2.GetHitBox().ToRectangle();
            Rectangle collisionBox = Rectangle.Intersect(linkBox, blockBox);

            if (!block1.Pushable) return;

            if (side == CollisionSide.Top)
            {
                block1.Position = new Point(blockPos1.X, blockPos1.Y - collisionBox.Height);
            }
                
            else if (side == CollisionSide.Left)
            {
                block1.Position = new Point(blockPos1.X - collisionBox.Width, blockPos1.Y);
            }
                
            else if (side == CollisionSide.Right)
            {
                block1.Position = new Point(blockPos1.X + collisionBox.Width, blockPos1.Y);
            }
                
            else if (side == CollisionSide.Bottom)
            {
                block1.Position = new Point(blockPos1.X, blockPos1.Y + collisionBox.Height);
            }
                
    

                
        }
    }
}
