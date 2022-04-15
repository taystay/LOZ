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
        private const int framesPerUpdate = UpdateSpeed.DragonUpdate;
        private int frameCounter = 0;
        private const int framesPerUpdate2 = UpdateSpeed.DragonShootUpdate;
        private int frameCounter2 = 0;
        private System.Random r = new Random();
        public Dragon(Point location)
        {
            Health = 6;
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateDragon();   
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X - 24, Position.Y - 24, 48, 24);
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
            frameCounter++;
            frameCounter2++;
            if (frameCounter > framesPerUpdate)
            {
                //velocity.X = random.Next(-2, 2);
                frameCounter = 0;
            }

            if (IsDamaged)
            {
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }

            modifyPosition(velocity.X,0);
            
            if (frameCounter2 > framesPerUpdate2) {

                int lastDigit = r.Next() % 10;
                if (lastDigit < 3)
                {
                    ProjectileTypes.QuadShot(Position);
                }
                else if (lastDigit >= 3 && lastDigit < 6)
                {
                    ProjectileTypes.Shotgun(Position);
                }
                else if (lastDigit >= 6)
                {
                    ProjectileTypes.Wave(Position);
                }
                else {
                    ProjectileTypes.SingleShot(Position); //never runs 
                }
               
                frameCounter2 = 0;
            }

            _texture.Update(timer);
        }

    }
}
