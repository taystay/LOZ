using System;
using LOZ.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;

namespace LOZ.EnemyClass
{
    class Skeleton : AbstractEnemy
    {
        public Skeleton(Point location) {

            position = location;
            _texture = EnemySpriteFactory.Instance.CreateSkeleton();
            random = new Random();
            xPosition = random.Next(700, 900);
            yPosition = random.Next(700, 900);

        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(position.X - WidthSpriteSection / 2, position.Y - HeightSpriteSection / 2, 48, 64);
        }

        public override void Update(GameTime timer) {

            if (position.X < xPosition)
            {
                position.X += 1;
            }
            else
            {
                position.X -= 1;
            }

            if (position.Y < yPosition)
            {
                position.Y += 1;
            }
            else
            {
                position.Y -= 1;
            }

            if (position.X == xPosition || position.Y == yPosition) {
                xPosition = random.Next(700, 900);
                yPosition = random.Next(700, 900);
            }          

            _texture.Update(timer);
        }

    }
}
