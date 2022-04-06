using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.GameState;

namespace LOZ.EnemyClass
{
    class Skeleton : AbstractEnemy
    {
        private double vMag = 2;
        private protected Vector2 velocity2;
        public Skeleton(Point location) 
        {
            Health = 3;
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateSkeleton();
            random = new Random();
            velocity2 = new Vector2(0, 0);
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X - WidthSpriteSection / 2, Position.Y - HeightSpriteSection / 2, 44, 60);
        }

        public override void Update(GameTime timer) {
            if (IsDamaged)
            {
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }
            if (knockedBack)
            {
                currentKnockBack++;
                if (currentKnockBack >= knockBackDuration)
                {
                    knockedBack = false;
                    currentKnockBack = 0;
                }
                else
                {
                    Position = new Point(Position.X + knockBackVel.X, Position.Y + knockBackVel.Y);
                }
            } 
            else
            {
                if ((int)timer.TotalGameTime.TotalMilliseconds % 1000 == 0)
                {
                    Point linkP = Room.Link.Position;

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
                modifyPosition((int)velocity2.X, (int)velocity2.Y);
            }
            _texture.Update(timer);
        }

    }
}
