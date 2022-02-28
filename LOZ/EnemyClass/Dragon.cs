using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.EnemyClass.Projectiles;
using LOZ.Collision;
using LOZ.GameState;


namespace LOZ.EnemyClass
{
    class Dragon : AbstractEnemy
    {

 
        public Dragon(Point location)
        {
            position = location;
            _texture = EnemySpriteFactory.Instance.CreateDragon();
            random = new Random();
            xPosition = random.Next(700, 900);
           
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
                TestingRoom.Instance.gameObjects.Add(new DragonBreathe(position,-1)); //top fireball
                TestingRoom.Instance.gameObjects.Add(new DragonBreathe(position,0)); //middle fireball
                TestingRoom.Instance.gameObjects.Add(new DragonBreathe(position,1)); //bottom fireball
            }

            _texture.Update(timer);
        }

    }
}
