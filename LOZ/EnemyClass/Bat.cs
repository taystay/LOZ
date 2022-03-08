using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;

namespace LOZ.EnemyClass
{
    class Bat : AbstractEnemy
    {
        public Bat(Point location)
        {
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateBat();
            random = new Random();

        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X-WidthSpriteSection/2, Position.Y - HeightSpriteSection/2 + 10, 67, 40);
        }

        public override void Update(GameTime timer)
        {
            if ((int)timer.TotalGameTime.TotalMilliseconds % 1000 == 0)
            {
                velocity.X = random.Next(-2, 2);
                velocity.Y = random.Next(-2, 2);
            }

            if(IsDamaged)
            {
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }

            modifyPosition(velocity.X, velocity.Y);

            _texture.Update(timer);
        }

    }
}
