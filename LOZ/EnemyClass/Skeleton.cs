using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;

namespace Sprint2.EnemyClass
{
    class Skeleton : IEnemy
    {
        private Point position;
        private ISprite skeleton;
        private int xPosition;
        private int yPosition;
        private Random random;

        public Skeleton(Point location) {

            position = location;
            skeleton = EnemySpriteFactory.Instance.CreateSkeleton();

            random = new Random();
            xPosition = random.Next(700, 900);
            yPosition = random.Next(700, 900);

        }

        public void Update(GameTime timer) {

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

            skeleton.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            skeleton.Draw(spriteBatch, position);

        }

    }
}
