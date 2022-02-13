using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Jelly : IEnemy
    {
        private Point position;
        private ISprite jelly;
        private int xPosition;
        private int yPosition;
        private Random random;

        public Jelly(Point location, double size)
        {

            position = location;
            jelly = EnemySpriteFactory.Instance.CreateJelly();
            jelly.SetSize(size);
            
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
