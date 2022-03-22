using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;

namespace LOZ.EnemyClass
{
    class Skeleton : AbstractEnemy
    {
        public Skeleton(Point location) 
        {
            Health = 100;
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateSkeleton();
            random = new Random();
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X - WidthSpriteSection / 2, Position.Y - HeightSpriteSection / 2, 44, 60);
        }

        public override void Update(GameTime timer) {

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
                    velocity.X = random.Next(-2, 2);
                    velocity.Y = random.Next(-2, 2);
                }
                if (IsDamaged)
                {
                    timeLeftDamage--;
                    if (timeLeftDamage <= 0)
                        IsDamaged = false;
                }

                modifyPosition(velocity.X, velocity.Y);
            }
            _texture.Update(timer);
        }

    }
}
