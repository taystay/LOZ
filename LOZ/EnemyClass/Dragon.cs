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
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateDragon();
            random = new Random();
            xPosition = random.Next(700, 900);
           
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(Position.X - WidthSpriteSection / 2, Position.Y - HeightSpriteSection / 2, 48, 64);
        }

        public override void Update(GameTime timer)
        {
            
            if (Position.X < xPosition)
            {
                modifyPosition(1, 0);

            } else
            {
                modifyPosition(-1, 0);
            }

            if (Position.X == xPosition )
            {
                xPosition = random.Next(700, 900);
            }
            

            if ((int) timer.TotalGameTime.TotalMilliseconds % 5000 == 0) {
                TestingRoom.Instance.gameObjects.Add(new DragonBreathe(Position,-1)); //top fireball
                TestingRoom.Instance.gameObjects.Add(new DragonBreathe(Position,0)); //middle fireball
                TestingRoom.Instance.gameObjects.Add(new DragonBreathe(Position,1)); //bottom fireball
            }

            _texture.Update(timer);
        }

    }
}
