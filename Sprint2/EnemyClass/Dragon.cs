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
        private IEnemy dragonsFire; // Dragon need not know about projectile and projectile not need know about dragon. IProjectile interface>>>
        private int xPosition;
        private Random random;
        private bool activeFire;

        public Dragon(Point location)
        {
            position = location;
            activeFire = false;
            dragon = EnemySpriteFactory.Instance.CreateDragon();
            dragonsFire = new DragonBreathe(this);
            random = new Random();
            xPosition = random.Next(0, 500);
        }

        public bool Fire
        {
            get
            {
                return activeFire;
            }
        }
        public Point Location
        {
            get {
                return position;
            }
        }

        public void Update(GameTime timer)
        {
            position.X = (position.X < xPosition) ? position.X += 1 : position.X -= 1;        
            if (position.X == xPosition )
            {
                xPosition = random.Next(0, 500);
            }

            //3 different projectiles split into different directions.
            //LIst<IProjectile>().add(DragonBall(Vector2(), Location()));
            //LIst<IProjectile>().add(DragonBall(Vector2(), Location()));
            //LIst<IProjectile>().add(DragonBall(Vector2(), Location()));

            if (timer.TotalGameTime.TotalMilliseconds % 2 == 0)
            {
                activeFire = !activeFire;
            }

            dragonsFire.Update(timer);
            dragon.Update(timer);
        }
        public void Draw(SpriteBatch spriteBatch)
        { 
            dragon.Draw(spriteBatch, position);
            if (activeFire)
            {
                dragonsFire.Draw(spriteBatch);
            }
        }

    }
}
