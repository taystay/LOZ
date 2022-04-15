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
        //private double _changeY;
        //private double _changeX;
        private const int animationLength = 300;
        private int length=0; 
        private float dt = .15f;
        private Vector2 k;

        public DragonBreathe(Point location, double changeX, double changeY)
        {
            dragonFire = EnemySpriteFactory.Instance.CreateFireBall();
            activeFire = true;
            //_changeY = changeY;
            //_changeX = changeX;

            fireBallPosition = new Point(location.X, location.Y);
            k = new Vector2((float)changeX, (float)changeY);
            k.Normalize();//https://docs.microsoft.com/en-us/dotnet/api/system.numerics.vector2.normalize?view=net-6.0

            //_changeY = changeY;
            //_changeX = changeX;
        }

        public Hitbox GetHitBox() {
            return new Hitbox(fireBallPosition.X-15, fireBallPosition.Y -15, 10 * 3, 10 * 3);
        }

        public void Update(GameTime timer)
        {
            length++;
            //k.Normalize();
            //https://docs.microsoft.com/en-us/dotnet/api/system.numerics.vector2.normalize?view=net-6.0

            fireBallPosition.X += (int)(k.X/dt);
            fireBallPosition.Y += (int)(k.Y/dt);
            
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
