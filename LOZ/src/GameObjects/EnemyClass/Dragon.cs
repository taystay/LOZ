using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.EnemyClass.Projectiles;
using LOZ.Collision;
using LOZ.Sound;

namespace LOZ.EnemyClass
{
    class Dragon : AbstractEnemy
    {
        private const int framesPerUpdate = UpdateSpeed.DragonUpdate;
        private const int framesPerUpdate2 = UpdateSpeed.DragonShootUpdate;
        private const int framesPerUpdate3 = UpdateSpeed.DragonShootUpdate / 16;
        private int frameCounter = 0;
        private int frameCounter2 = 0;
        private int frameCounter3 = 0;
        private Random r = new Random();
        private bool quad = false;
        private int quadShots = 0;
        private int coolDown = 125;

        public Dragon(Point location)
        {
            Health = 6;
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateDragon();   
        }
        public override Hitbox GetHitBox() =>
            new Hitbox(Position.X - 24, Position.Y - 24, 48, 24);
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
                frameCounter2 = 0;
            }

            if (coolDown <0)
            {
                DragonAttack();
                coolDown = 125;
            }

            if (quad)
            {
                frameCounter3++;
                if (frameCounter3 > framesPerUpdate3)
                {
                    quadShots++;
                    ProjectileTypes.QuadShot(Position);
                    frameCounter3 = 0;
                }
                if (quadShots > 3)
                {
                    quadShots = 0;
                    quad = false;
                }
            }

            coolDown--;
            _texture.Update(timer);
        }


        private void DragonAttack() {

            int lastDigit = r.Next() % 4;
            if (lastDigit == 0)
                quad = true;
            else if (lastDigit == 1)
                ProjectileTypes.Shotgun(Position);
            else if (lastDigit == 2)
                ProjectileTypes.Wave(Position);
            else
            {
                ProjectileTypes.SingleShot(Position); //never runs 
            }

        }
    }
}
