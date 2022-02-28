using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace LOZ.Collision
{
    enum CollisionSide
    {
        Top,
        Bottom,
        Left,
        Right
    }
    class CollisionDetection
    {
        CollisionBehavior collisionBehavior;
        public CollisionDetection()
        {
            collisionBehavior = new CollisionBehavior();

        }
        public void CheckCollision(IGameObjects objOne, IGameObjects objTwo)
        {
            Rectangle rec1 = objOne.GetHitBox();
            Rectangle rec2 = objTwo.GetHitBox();

            if (rec1.Intersects(rec2)) {
                //rec2 is the focal point 

                //if positive difference in X: rec1 is right side of rec2(collision = right)
                //if negative difference in X: rec1 is left side of rec2 (collision =left)
                //if positive difference in Y: rec1 is bottom of rec2 (collision =bottom)
                //if negative difference in Y: rec1 is top of rec2(collision = top)
                int differenceX = rec1.X - rec2.X;
                int differenceY = rec1.Y - rec2.Y;
                Rectangle intersectRect = Rectangle.Intersect(rec1, rec2);

                if (intersectRect.Width > intersectRect.Height)
                {
                    if (differenceY < 0)
                    {
                        Console.WriteLine("TRUE");
                        collisionBehavior.HandleCollision(objOne, objTwo, CollisionSide.Top);
                    }
                    else
                    {
                        Console.WriteLine("TRUE");
                        collisionBehavior.HandleCollision(objOne, objTwo, CollisionSide.Bottom);
                    }
                }
                else 
                {
                    if (differenceX < 0)
                    {
                        Console.WriteLine("TRUE");
                        collisionBehavior.HandleCollision(objOne, objTwo, CollisionSide.Left);
                    }
                    else
                    {
                        Console.WriteLine("TRUE");
                        collisionBehavior.HandleCollision(objOne, objTwo, CollisionSide.Right);
                    }

                }

          
            }
        }

    }
}
