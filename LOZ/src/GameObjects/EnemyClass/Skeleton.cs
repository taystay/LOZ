using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.GameStateReference;

namespace LOZ.EnemyClass
{
    class Skeleton : AbstractEnemy
    {
        private const double vMag = 2;
        private protected Vector2 velocity2;
        private const int framesPerUpdate = UpdateSpeed.SkeletonUpdate;
        private int frameCounter = 0;
        public Skeleton(Point location) 
        {
            Health = 3;
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateSkeleton();
            velocity2 = new Vector2(0, 0);
        }
        public Skeleton(Point location, bool hasKey) : this(location)
        {
            this.hasKey = hasKey;
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X - 22, Position.Y - 30, 44, 60);
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
                frameCounter++;
                if (frameCounter > framesPerUpdate)
                {
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
                    frameCounter = 0;
                }              
                modifyPosition((int)velocity2.X, (int)velocity2.Y);
            }
            _texture.Update(timer);
        }

    }
}
