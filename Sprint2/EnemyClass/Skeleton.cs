using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Skeleton : IEnemy
    {
        private Point position;
        private ISprite skeleton;

        public Skeleton(Point location) {

            position = location;
            skeleton = EnemySpriteFactory.Instance.CreateSkeleton();

        }

        public void Update(GameTime timer) {

            var random = new Random();

            position.X = (int)(timer.ElapsedGameTime.TotalSeconds * random.Next(10, 100));
            position.Y = (int)(timer.ElapsedGameTime.TotalSeconds * random.Next(10, 100));
            skeleton.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            skeleton.Draw(spriteBatch, position);

        }

    }
}
