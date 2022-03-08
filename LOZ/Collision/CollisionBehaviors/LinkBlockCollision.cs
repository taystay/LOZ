using Microsoft.Xna.Framework;
using LOZ.LinkClasses;
using LOZ.EnvironmentalClasses;

namespace LOZ.Collision
{
    public static class LinkBlockCollision
    {
        public static void Handle(IGameObjects linkObj, IGameObjects blockObj, CollisionSide side)
        {
            if (TypeC.Check(blockObj, typeof(StairsBlock))) return;
            ILink link = (ILink)linkObj;
            Rectangle linkBox = linkObj.GetHitBox().ToRectangle();
            Rectangle blockBox = blockObj.GetHitBox().ToRectangle();

            Point linkPos = link.Position;
            Rectangle collisionBox = Rectangle.Intersect(linkBox, blockBox);

            //Make link not be able to move forward at all.
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
