using System;
using LOZ.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;


namespace LOZ.EnemyClass
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

            jelly.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            jelly.Draw(spriteBatch, position);

        }

    }
}
