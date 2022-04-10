using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.EnemyClass.Projectiles;
using LOZ.Collision;
using LOZ.GameStateReference;
using LOZ.Sound;


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
            return new Hitbox(Position.X - 24, Position.Y - 30, 48, 24);
        }

        public override void TakeDamage(int damage)
        {
            if (!IsDamaged)
            {
                IsDamaged = true;
                Health -= damage;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Boss_Hit);
                timeLeftDamage = InivincibilityFrames;
            }
        }

        public override bool IsActive()
        {
            if (Health <= 0)
            {
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Boss_Scream1);
                return false;
            }

            return isActive;
        }

        public override void Update(GameTime timer)
        {

            if ((int)timer.TotalGameTime.TotalMilliseconds % 1000 == 0)
            {
                velocity.X = random.Next(-4, 4);
            
            }

            if (IsDamaged)
            {
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }

            modifyPosition(velocity.X,0);

            if ((int) timer.TotalGameTime.TotalMilliseconds % 5000 == 0) {
                RoomReference.AddItem(new DragonBreathe(Position,-1)); //top fireball
                RoomReference.AddItem(new DragonBreathe(Position,0)); //middle fireball
                RoomReference.AddItem(new DragonBreathe(Position,1)); //bottom fireball
            }

            _texture.Update(timer);
        }

    }
}
