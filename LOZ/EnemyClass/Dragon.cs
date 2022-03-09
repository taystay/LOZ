using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.EnemyClass.Projectiles;
using LOZ.Collision;
using LOZ.GameState;


namespace LOZ.EnemyClass
{
    class Dragon : AbstractEnemy
    {
        public Dragon(Point location)
        {
            Health = 6;
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateDragon();
            random = new Random();     
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X - 24, Position.Y - 32, 48, 64);
        }

        public override void Update(GameTime timer)
        {


            if ((int)timer.TotalGameTime.TotalMilliseconds % 1000 == 0)
            {
                velocity.X = random.Next(-2, 2);
            
            }

            if (IsDamaged)
            {
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }

            modifyPosition(velocity.X,0);

            if ((int) timer.TotalGameTime.TotalMilliseconds % 5000 == 0) {
                CurrentRoom.Instance.Room.gameObjects.Add(new DragonBreathe(Position,-1)); //top fireball
                CurrentRoom.Instance.Room.gameObjects.Add(new DragonBreathe(Position,0)); //middle fireball
                CurrentRoom.Instance.Room.gameObjects.Add(new DragonBreathe(Position,1)); //bottom fireball
            }

            _texture.Update(timer);
        }

    }
}
