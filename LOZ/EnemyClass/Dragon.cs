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
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(Position.X - WidthSpriteSection / 2, Position.Y - HeightSpriteSection / 2, 48, 64);
        }

        public override void Update(GameTime timer)
        {


            if ((int)timer.TotalGameTime.TotalMilliseconds % 1000 == 0)
            {
                velocity.X = random.Next(-4, 4);
            
            }

            modifyPosition(velocity.X,0);

            if ((int) timer.TotalGameTime.TotalMilliseconds % 5000 == 0) {
                TestingRoom.Instance.gameObjects.Add(new DragonBreathe(Position,-1)); //top fireball
                TestingRoom.Instance.gameObjects.Add(new DragonBreathe(Position,0)); //middle fireball
                TestingRoom.Instance.gameObjects.Add(new DragonBreathe(Position,1)); //bottom fireball
            }

            _texture.Update(timer);
        }

    }
}
