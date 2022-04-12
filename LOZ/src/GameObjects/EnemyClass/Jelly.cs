using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.GameStateReference;


namespace LOZ.EnemyClass
{
    class Jelly : AbstractEnemy
    {
        private const double vMag = 1;
        private protected Vector2 velocity2;
        private const int framesPerUpdate = 500;
        private int frameCounter = 0;
        public Jelly(Point location)
        {
            Health = 1;
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateJelly();       
            velocity2 = new Vector2(0, 0);
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X - 6 , Position.Y - 9, 16, 19);
        }



        public override void Update(GameTime timer)
        {
            frameCounter++;
            if(frameCounter > framesPerUpdate)
            {
                frameCounter = 0;
                Point linkP = RoomReference.GetLink().Position;

                //https://stackoverflow.com/questions/41317291/setting-the-magnitude-of-a-2d-vector#41321162
                if (random.Next(2) % 2 == 0)
                {
                    double dx = (linkP.X - Position.X);
                    double dy = (linkP.Y - Position.Y);
                    double mag = Math.Sqrt(dx * dx + dy * dy);
                    dx = dx * vMag / mag;
                    dy = dy * vMag / mag;
                    velocity2.X = (float)dx;
                    velocity2.Y = (float)dy;
                }
                else
                {
                    double dx = (int)random.Next(-2, 2);
                    double dy = (int)random.Next(-2, 2);
                    velocity2.X = (float)dx;
                    velocity2.Y = (float)dy;
                }
            }
            if (IsDamaged)
            {
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }

            modifyPosition((int)velocity2.X, (int)velocity2.Y);

            _texture.Update(timer);
        }

    }
}
