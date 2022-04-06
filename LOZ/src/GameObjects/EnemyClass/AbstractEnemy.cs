﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using System;
using LOZ.Collision;
using LOZ.GameState;
using LOZ.ItemsClasses;
using LOZ.Sound;

namespace LOZ.EnemyClass
{
    abstract class AbstractEnemy : IEnemy
    {
        
        private protected const int HeightSpriteSection = 83;
        private protected const int WidthSpriteSection = 64;
        private protected const int InivincibilityFrames = 30;
        public bool IsDamaged { get; set; }
        private protected int timeLeftDamage = 100;
        private protected ISprite _texture;
        public Point Position { get; set; }
        public int Health { get; set; } = 6;
        private protected Point velocity;
        private protected Random random;
        private protected bool isActive = true;
        protected static int knockBackDuration = 20;
        protected static int currentKnockBack = 0;
        protected static bool knockedBack = false;
        public Point knockBackVel = new Point(0, 0);

        public void KillItem()
        {
            isActive = false;
        }

        public virtual void TakeDamage(int damage)
        {
            if(!IsDamaged)
            {
                IsDamaged = true;
                Health -= damage;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Enemy_Hit);
                timeLeftDamage = InivincibilityFrames;
            } 
        }
        public virtual bool IsActive()
        {
            if (Health <= 0)
            {
                int num = random.Next();
                if (num % 2 == 0)
                {
                    CurrentRoom.Instance.Room.GameObjects.Add(new Rupee(Position));        
                } else if (num % 3 == 2)
                {
                    CurrentRoom.Instance.Room.GameObjects.Add(new Clock(Position));
                }
                else if (num % 6 == 0)
                {
                    CurrentRoom.Instance.Room.GameObjects.Add(new Fairy(Position));
                }
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Enemy_Die);
                return false;
            }
            
            return isActive;
        }
        protected void modifyPosition(int dx, int dy)
        {
            if (Room.RoomInventory.hasClock) return;
            Position = new Point(Position.X + dx, Position.Y + dy);
        }
        public abstract Hitbox GetHitBox();
        public void KnockBack(Point vel)
        {
            if (!knockedBack)
            {
                knockedBack = true;
                knockBackVel = vel;
                return;
            }
        }
        public abstract void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsDamaged)
                _texture.Draw(spriteBatch, Position, Color.Red);
            else 
                _texture.Draw(spriteBatch, Position);
        }
    }
}
