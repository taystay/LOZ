using Microsoft.Xna.Framework;

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
        public CollisionDetection()
        {
        }
        public void CheckCollision(IGameObjects objOne, IGameObjects objTwo)
        {
            Rectangle rec1 = objOne.GetHitBox();
            Rectangle rec2 = objTwo.GetHitBox();

            if (rec1.Intersects(rec2)) {
                //rec1 is the focal point 

                //if positive difference in X: rec2 is left side(collision = left)
                //if negative difference in X: rec2 is right side (collision =right)
                //if positive difference in Y: rec2 is top (collision =top)
                //if negative difference in Y: rec2 is bottom (collision = bottom) 
                int differenceInX = rec1.X - rec2.X;
                int differenceInY = rec1.Y - rec2.Y;
                Rectangle intersectRect = Rectangle.Intersect(rec1, rec2);
                
            
            
            }
        }


    }
}
