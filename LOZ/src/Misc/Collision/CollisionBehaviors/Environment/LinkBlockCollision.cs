using Microsoft.Xna.Framework;
using LOZ.LinkClasses;
using LOZ.EnvironmentalClasses;
using LOZ.DungeonClasses;
using LOZ.GameStateReference;
using LOZ.Room;

namespace LOZ.Collision
{
    public static class LinkBlockCollision
    {
        public static void Handle(IGameObjects linkObj, IGameObjects blockObj, CollisionSide side)
        {
            ILink link = (ILink)linkObj;
            IEnvironment block = (IEnvironment)blockObj;
            Point linkPos = link.Position;
            Point blockPos = block.Position;
            Rectangle linkBox = linkObj.GetHitBox().ToRectangle();
            Rectangle blockBox = blockObj.GetHitBox().ToRectangle();
            Rectangle collisionBox = Rectangle.Intersect(linkBox, blockBox);
            
            if (block.Pushable)
            {
                if (side == CollisionSide.Top)
                    block.Position = new Point(blockPos.X, blockPos.Y + collisionBox.Height);
                else if (side == CollisionSide.Left)
                    block.Position = new Point(blockPos.X + collisionBox.Width, blockPos.Y);
                else if (side == CollisionSide.Right)
                    block.Position = new Point(blockPos.X - collisionBox.Width, blockPos.Y);
                else if (side == CollisionSide.Bottom)
                    block.Position = new Point(blockPos.X, blockPos.Y - collisionBox.Height);
                Point3D roomCoor = RoomReference.GetCurrLocation();
            } else
            {
                if (side == CollisionSide.Top)
                    link.Position = new Point(linkPos.X, linkPos.Y - collisionBox.Height);
                else if (side == CollisionSide.Left)
                    link.Position = new Point(linkPos.X - collisionBox.Width, linkPos.Y);
                else if (side == CollisionSide.Right)
                    link.Position = new Point(linkPos.X + collisionBox.Width, linkPos.Y);
                else if (side == CollisionSide.Bottom)
                    link.Position = new Point(linkPos.X, linkPos.Y + collisionBox.Height);
            }
        }
    }
}
