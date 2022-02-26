using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;

namespace LOZ.EnemyClass
{
    class Bat : AbstractEnemy
    {
        public Bat(Point location)
        {
            position = location;
            _texture = EnemySpriteFactory.Instance.CreateBat();
            random = new Random();
            xPosition = random.Next(700, 900);
            yPosition = random.Next(700, 900);

        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(position.X-WidthSpriteSection/2, position.Y - HeightSpriteSection/2, 67, 40);
        }

        public override void Update(GameTime timer)
        {
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

            if (position.X == xPosition || position.Y == yPosition)
            {
                xPosition = random.Next(700, 900);
                yPosition = random.Next(700, 900);
            }
            _texture.Update(timer);
        }

    }
}
