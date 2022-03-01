using System;
using LOZ.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;

namespace LOZ.EnemyClass
{
    class Skeleton : AbstractEnemy
    {
        public Skeleton(Point location) 
        {
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateSkeleton();
            random = new Random();
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(Position.X - WidthSpriteSection / 2, Position.Y - HeightSpriteSection / 2, 48, 64);
        }

        public override void Update(GameTime timer) {

            if ((int)timer.TotalGameTime.TotalMilliseconds % 1000 == 0)
            {
                velocity.X = random.Next(-4, 4);
                velocity.Y = random.Next(-4, 4);
            }
            modifyPosition(velocity.X, velocity.Y);

            _texture.Update(timer);
        }

    }
}
