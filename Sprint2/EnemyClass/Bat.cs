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

        public Bat(Point location)
        {

            position = location;
            bat = EnemySpriteFactory.Instance.CreateBat();

        }

        public void Update(GameTime timer)
        {

            //var random = new Random();

            /*  position.X = (int)(timer.ElapsedGameTime.TotalSeconds * random.Next(10, 100));
              position.Y = (int)(timer.ElapsedGameTime.TotalSeconds * random.Next(10, 100));*/

            bat.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            bat.Draw(spriteBatch, position);

        }

    }
}
