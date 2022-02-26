using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.EnemyClass.Projectiles;


namespace LOZ.EnemyClass
{
    class Dragon : AbstractEnemy
    {
        private List<IProjectile> fireBalls;
 
        public Dragon(Point location, List<IProjectile> dragonBreathe)
        {
            position = location;
            _texture = EnemySpriteFactory.Instance.CreateDragon();
            random = new Random();
            xPosition = random.Next(700, 900);
            fireBalls = dragonBreathe;
           
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(position.X - WidthSpriteSection / 2, position.Y - HeightSpriteSection / 2, 48, 64);
        }

        public override void Update(GameTime timer)
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

            _texture.Update(timer);
        }

    }
}
