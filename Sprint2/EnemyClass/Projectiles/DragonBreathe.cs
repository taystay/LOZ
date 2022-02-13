using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class DragonBreathe : IProjectile
    {
        private Point fireBallPosition;
        private ISprite dragonFire;
        private bool activeFire;
        private int changeY;
        private const int animationLength = 250;
        private int length=0;

        public DragonBreathe(Point location, int changeYPosition)
        {
            dragonFire = EnemySpriteFactory.Instance.CreateFireBall();
            activeFire = true;
            fireBallPosition = location;
            changeY = changeYPosition;
        }
        
        public void Update(GameTime timer)
        {
            length++;
           
            fireBallPosition.Y += changeY;
            fireBallPosition.X -= 2;
            
            dragonFire.Update(timer);
        }

        public bool IsActive() {

            if (animationLength == length)
            {
                activeFire = false;
            }

            return activeFire;
        
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            dragonFire.Draw(spriteBatch, fireBallPosition);
        }

    }
}
