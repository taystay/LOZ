using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;

namespace LOZ.EnemyClass
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
            xPosition = random.Next(700, 900);
            yPosition = random.Next(700, 900);

        }

        public void Update(GameTime timer)
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
            bat.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            bat.Draw(spriteBatch, position);

        }

    }
}
