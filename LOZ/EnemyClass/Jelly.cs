using System;
using LOZ.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;


namespace LOZ.EnemyClass
{
    class Jelly : AbstractEnemy
    {

        public Jelly(Point location)
        {
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateJelly();       
            random = new Random();
            xPosition = random.Next(700, 900);
            yPosition = random.Next(700, 900);
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(Position.X - WidthSpriteSection / 2, Position.Y - HeightSpriteSection / 2, 16, 19);
        }

        public override void Update(GameTime timer)
        {
            if (Position.X < xPosition)
            {
                modifyPosition(1, 0);
            }
            else
            {
                modifyPosition(-1, 0);
            }

            if (Position.Y < yPosition)
            {
                modifyPosition(0, 1);
            }
            else
            {
                modifyPosition(0, -1);
            }

            if (Position.X == xPosition || Position.Y == yPosition)
            {
                xPosition = random.Next(700, 900);
                yPosition = random.Next(700, 900);
            }
            _texture.Update(timer);
        }

    }
}
