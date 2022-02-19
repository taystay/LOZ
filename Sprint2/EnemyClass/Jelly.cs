using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;


namespace Sprint2.EnemyClass
{
    class Jelly : IEnemy
    {
        private Point position;
        private ISprite jelly;
        private int xPosition;
        private int yPosition;
        private Random random;

        public Jelly(Point location)
        {

            position = location;
            jelly = EnemySpriteFactory.Instance.CreateJelly();
            
            random = new Random();
            xPosition = random.Next(700, 900);
            yPosition = random.Next(700, 900);


        }

        public void Update(GameTime timer)
        {


            position.X = (position.X < xPosition) ? position.X += 1 : position.X -= 1;
            position.Y = (position.Y < yPosition) ? position.Y += 1 : position.Y -= 1;

            if (position.X == xPosition || position.Y == yPosition)
            {
                xPosition = random.Next(700, 900);
                yPosition = random.Next(700, 900);
            }

            jelly.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            jelly.Draw(spriteBatch, position);

        }

    }
}
