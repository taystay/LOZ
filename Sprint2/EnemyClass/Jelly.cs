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

        public Jelly(Point location)
        {

            position = location;
            jelly = EnemySpriteFactory.Instance.CreateJelly();

        }

        public void Update(GameTime timer)
        {

            //var random = new Random();

            /*  position.X = (int)(timer.ElapsedGameTime.TotalSeconds * random.Next(10, 100));
              position.Y = (int)(timer.ElapsedGameTime.TotalSeconds * random.Next(10, 100));*/

            jelly.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            jelly.Draw(spriteBatch, position);

        }

    }
}
