using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Dragon : IEnemy
    {
        private Point position;
        private ISprite dragon;

        public Dragon(Point location)
        {

            position = location;
            dragon = EnemySpriteFactory.Instance.CreateDragon();

        }

        public void Update(GameTime timer)
        {

            //var random = new Random();

            /*  position.X = (int)(timer.ElapsedGameTime.TotalSeconds * random.Next(10, 100));
              position.Y = (int)(timer.ElapsedGameTime.TotalSeconds * random.Next(10, 100));*/

            dragon.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            dragon.Draw(spriteBatch, position);

        }

    }
}
