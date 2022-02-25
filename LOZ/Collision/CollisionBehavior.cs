using System;
using System.Collections.Generic;
using System.Text;

namespace LOZ.Collision.Iterator
{
    class CollisionBehavior
    {
        public CollisionBehavior()
        {

        }
        public void HandleCollision(IGameObjects one, IGameObjects two, CollisionSide side)
        {
            /*
             * IDEA 1: Use enums and another class to tell us the type of collision and another class to handle the collison behavior
             * type = CollisionType(one, two);
             * Collide(type, side);
             * 
             * (IMPLEMENT THIS ONE) IDEA 2: Use if else to determine which type of collision and then call another class and method
             * IF STATEMENTS
             * if(one.InstanceOf(new ILink) && two.InstanceOf(new IEnvironemnt)) {
             *      LinkEnvironmentCollisionHandler(one, two, side);
             * } else if (So on and so forth) {}
             */
        }
    }
}
