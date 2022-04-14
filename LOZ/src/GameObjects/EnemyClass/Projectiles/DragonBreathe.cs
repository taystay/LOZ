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
        private int changeX;
        private const int animationLength = 300;
        private int length=0;

        public DragonBreathe(Point location, int changeYPosition, int changeXPosition)
        {
            dragonFire = EnemySpriteFactory.Instance.CreateFireBall();
            activeFire = true;

            fireBallPosition = new Point(location.X, location.Y);
            //fireBallPosition.Y = location.Y;
            //fireBallPosition.X = location.X;
            changeY = changeYPosition;
            changeX = changeXPosition;
        }

        public Hitbox GetHitBox() {
            return new Hitbox(fireBallPosition.X-15, fireBallPosition.Y -15, 10 * 3, 10 * 3);
        }
        
        public void Update(GameTime timer)
        {
            length++;
           
            fireBallPosition.Y += changeY;
            fireBallPosition.X += changeX;
            
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
