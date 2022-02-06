using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class DragonBreathe : IEnemy
    {
        private Point fireBallPosition;
        private ISprite dragonFire1;
        private ISprite dragonFire2;
        private ISprite dragonFire3;
        private Dragon dragon;
        private int changeY;
        //private List<ISprite> dragonFire;

        /*I decided to create 3 sprites for instead of using 1 due to position of Y constantly changing
        also for future collision would be individual not all together*/
        public DragonBreathe(Dragon d)
        {
            fireBallPosition = d.Location;
           /* dragonFire.Add(EnemySpriteFactory.Instance.CreateFire());
            dragonFire.Add(EnemySpriteFactory.Instance.CreateFire());
            dragonFire.Add(EnemySpriteFactory.Instance.CreateFire());*/
            dragonFire1 = EnemySpriteFactory.Instance.CreateFire();
            dragonFire2 = EnemySpriteFactory.Instance.CreateFire();
            dragonFire3 = EnemySpriteFactory.Instance.CreateFire();
            dragon = d;
            changeY = 0;
 
        }
        public void Update(GameTime timer)
        {
            if (dragon.Fire) {
                fireBallPosition.X -= 4;
                changeY += 3;
                dragonFire1.Update(timer);
                dragonFire2.Update(timer);
                dragonFire3.Update(timer);
            }else{
                fireBallPosition = dragon.Location;
                changeY = 0;
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //order of fire ball is top, middle, and bottom
            if (dragon.Fire)
            {
                dragonFire1.Draw(spriteBatch, new Point(fireBallPosition.X,fireBallPosition.Y - changeY));
                dragonFire2.Draw(spriteBatch, fireBallPosition);
                dragonFire2.Draw(spriteBatch, new Point(fireBallPosition.X, fireBallPosition.Y + changeY));
            }
        }

    }
}
