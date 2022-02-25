using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.Collision.Iterator
{
    enum CollisionSide
    {
        Top,
        Bottom,
        Left,
        Right
    }
    //private bool collides;
    //private CollisionSide side; 
    class CollisionDetection
    { 
        public CollisionDetection()
        {

        }
        public void CheckCollision(IGameObjects objOne, IGameObjects objTwo)
        {
            /*
            if(collides)
                CollsionBehavior(objOne, objTwo, side)
            */
        }
    }
}
