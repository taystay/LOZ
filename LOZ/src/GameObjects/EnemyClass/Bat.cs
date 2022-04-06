using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.GameState;

namespace LOZ.EnemyClass
{
    class Bat : AbstractEnemy
    {
        private double vMag = 1.5;
        private protected Vector2 velocity2;
        public Bat(Point location)
        {
            Health = 1;
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateBat();
            random = new Random();
            velocity2 = new Vector2(0, 0);
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X - 33, Position.Y - 40, 30, 30);
        }

        public override void Update(GameTime timer)
        {
            if ((int)timer.TotalGameTime.TotalMilliseconds % 1000 == 0)
            {
                Point linkP = Room.Link.Position;

                //https://stackoverflow.com/questions/41317291/setting-the-magnitude-of-a-2d-vector#41321162
                if (random.Next(2) % 3 != 0)
                {
                    double dx = (linkP.X - Position.X);
                    double dy = (linkP.Y - Position.Y);

                    double mag = Math.Sqrt(dx * dx + dy * dy);

                    dx = dx * vMag / mag;
                    dy = dy * vMag / mag;
                    velocity2.X = (float)dx;
                    velocity2.Y = (float)dy;
                } else
                {
                    double dx = (int)random.Next(-2,2);
                    double dy = (int)random.Next(-2,2);
                    velocity2.X = (float)dx;
                    velocity2.Y = (float)dy;
                }
            }

            if(IsDamaged)
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
