﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;


namespace LOZ.EnemyClass.Projectiles
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

        public Rectangle GetHitBox() {
            return new Rectangle(fireBallPosition.X , fireBallPosition.Y , 10 * 3, 10 * 3);
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
