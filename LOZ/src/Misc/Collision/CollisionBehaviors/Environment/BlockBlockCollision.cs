using Microsoft.Xna.Framework;
using LOZ.EnvironmentalClasses;
using LOZ.GameStateReference;

namespace LOZ.Collision
{
    public static class BlockBlockCollision
    {
        public static void Handle(IGameObjects blockObj1, IGameObjects blockObj2, CollisionSide side)
        {
            IEnvironment block1 = (IEnvironment)blockObj1;
            IEnvironment block2 = (IEnvironment)blockObj2;
            Point blockPos1 = block1.Position;
            Rectangle linkBox = block1.GetHitBox().ToRectangle();
            Rectangle collisionBox = Rectangle.Intersect(linkBox, blockObj2.GetHitBox().ToRectangle());
            Point linkPos = RoomReference.GetLink().Position;

            if (!block1.Pushable) return;

            if (side == CollisionSide.Top && !TypeC.Check(block2, typeof(StairsBlock)))
            {
                block1.Position = new Point(blockPos1.X, blockPos1.Y - collisionBox.Height);
                RoomReference.GetLink().Position = new Point(linkPos.X, linkPos.Y - collisionBox.Height);
            }
                
            else if (side == CollisionSide.Left && !TypeC.Check(block2, typeof(StairsBlock)))
            {
                block1.Position = new Point(blockPos1.X - collisionBox.Width, blockPos1.Y);
                RoomReference.GetLink().Position = new Point(linkPos.X - collisionBox.Width, linkPos.Y);
            }
                
            else if (side == CollisionSide.Right && !TypeC.Check(block2, typeof(StairsBlock)))
            {
                block1.Position = new Point(blockPos1.X + collisionBox.Width, blockPos1.Y);
                RoomReference.GetLink().Position = new Point(linkPos.X + collisionBox.Width, linkPos.Y);
            }
                
            else if (side == CollisionSide.Bottom && !TypeC.Check(block2, typeof(StairsBlock)))
            {
                block1.Position = new Point(blockPos1.X, blockPos1.Y + collisionBox.Height);
                RoomReference.GetLink().Position = new Point(linkPos.X, linkPos.Y + collisionBox.Height);
            }    
        }
    }
}
