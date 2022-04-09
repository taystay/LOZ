using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;


namespace LOZ.EnemyClass.Projectiles
{
    class DragonBreathe : IProjectile
    {
        private Point fireBallPosition;
        private ISprite dragonFire;
        public bool activeFire { get; set; }
        private int changeY;
        private const int animationLength = 250;
        private int length=0;

        public DragonBreathe(Point location, int changeYPosition)
        {
            dragonFire = EnemySpriteFactory.Instance.CreateFireBall();
            activeFire = true;
            fireBallPosition.Y = location.Y - 20 ;
            fireBallPosition.X = location.X - 40;
            changeY = changeYPosition;
        }

        public Hitbox GetHitBox() {
            return new Hitbox(fireBallPosition.X , fireBallPosition.Y , 10 * 3, 10 * 3);
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

        public void Draw(SpriteBatch spriteBatch, Point offset)
        {
            dragonFire.Draw(spriteBatch, fireBallPosition + offset);
        }

    }
}
