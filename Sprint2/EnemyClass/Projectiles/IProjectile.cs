using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.EnemyClass.Projectiles
{
    interface IProjectile
    {
        public Boolean IsActive(); //Projectiles should tell the user when they are done.
        public void Update(); //Update positions and stuff.
        public void Draw(); //Draw where is needs to be.
    }
}
