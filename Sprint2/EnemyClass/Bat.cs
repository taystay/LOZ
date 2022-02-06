using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Bat : IEnemy
    {
        private Point position;
        private ISprite bat;
        private int xPosition;
        private int yPosition;
        private Random random;

        public Bat(Point location)
        {

            position = location;
            bat = EnemySpriteFactory.Instance.CreateBat();
            random = new Random();
            xPosition = random.Next(0, 500);
            yPosition = random.Next(0, 500);

        }

        public void Update(GameTime timer)
        {
            position.X = (position.X < xPosition) ? position.X += 1 : position.X -= 1;
            position.Y = (position.Y < yPosition) ? position.Y += 1 : position.Y -= 1;

            if (position.X == xPosition || position.Y == yPosition)
            {
                xPosition = random.Next(0, 500);
                yPosition = random.Next(0, 500);
            }
            bat.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            bat.Draw(spriteBatch, position);

        }

    }
}
