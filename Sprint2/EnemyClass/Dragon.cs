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
        private int xPosition;
        private Random random;
        private List<IProjectile> fireBalls;
 
        public Dragon(Point location, List<IProjectile> dragonBreathe)
        {
            position = location;
            dragon = EnemySpriteFactory.Instance.CreateDragon();          
            random = new Random();
            xPosition = random.Next(700, 900);
            fireBalls = dragonBreathe;
           
        }
        public void Update(GameTime timer)
        {
            position.X = (position.X < xPosition) ? position.X += 1 : position.X -= 1; 
            if (position.X == xPosition )
            {
                xPosition = random.Next(700, 900);
            }
            

            if ((int) timer.TotalGameTime.TotalMilliseconds % 5000 == 0) {
                fireBalls.Add(new DragonBreathe(position,-1)); //top fireball
                fireBalls.Add(new DragonBreathe(position,0)); //middle fireball
                fireBalls.Add(new DragonBreathe(position,1)); //bottom fireball
            }

            dragon.Update(timer);
        }
        public void Draw(SpriteBatch spriteBatch)
        { 
            dragon.Draw(spriteBatch, position);
            
        }

    }
}
