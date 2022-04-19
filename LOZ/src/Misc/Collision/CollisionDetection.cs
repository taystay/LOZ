using Microsoft.Xna.Framework;
using System;
using LOZ.ItemsClasses;
using LOZ.LinkClasses;

namespace LOZ.Collision
{
    public enum CollisionSide
    {
        Top,
        Bottom,
        Left,
        Right
    }
    class CollisionDetection
    {
        CollisionBehavior collisionBehavior;
        public CollisionDetection() => collisionBehavior = new CollisionBehavior();
        public void CheckCollision(IGameObjects objOne, IGameObjects objTwo)
        {
            Rectangle rec1 = objOne.GetHitBox().ToRectangle();
            Rectangle rec2 = objTwo.GetHitBox().ToRectangle();
            if (!rec1.Intersects(rec2))
            {
                if(TypeC.CheckPair(objOne, typeof(ILink), objTwo, typeof(IItem)))
                {
                    if (TypeC.Check(objTwo, typeof(FireItem)) || TypeC.Check(objTwo, typeof(IPlayerProjectile))) return;
                    int linkx = rec1.X += rec1.Width / 2;
                    int linkY = rec1.Y += rec1.Height / 2;
                    int itemX = rec2.X += rec2.Width / 2;
                    int itemY = rec2.Y += rec2.Height / 2;
                    int dx = linkx - itemX;
                    int dy = linkY - itemY;

                    double dtotal = Math.Sqrt(Math.Pow(dx,2) + Math.Pow(dy,2));
                    int pickupradius = 48;
                    if (dtotal > pickupradius) return;
                    IItem item = (IItem)objTwo;
                    item.SetPosition(new Point(rec1.X, rec1.Y));
                }

                return;
            }
            int differenceX = rec1.X - rec2.X;
            int differenceY = rec1.Y - rec2.Y;
            Rectangle intersectRect = Rectangle.Intersect(rec1, rec2);
            if (intersectRect.Width > intersectRect.Height)
            {
                if (differenceY < 0)
                {
                    collisionBehavior.HandleCollision(objOne, objTwo, CollisionSide.Top);
                }
                else
                {
                    collisionBehavior.HandleCollision(objOne, objTwo, CollisionSide.Bottom);
                }
            }
            else 
            {
                if (differenceX < 0)
                {
                    collisionBehavior.HandleCollision(objOne, objTwo, CollisionSide.Left);
                }
                else
                {
                    collisionBehavior.HandleCollision(objOne, objTwo, CollisionSide.Right);
                }
            }
        }
    }
}
