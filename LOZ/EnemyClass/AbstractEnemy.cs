using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using System;
using LOZ.Collision;

namespace LOZ.EnemyClass
{
    abstract class AbstractEnemy : IEnemy
    {
        
        private protected const int HeightSpriteSection = 83;
        private protected const int WidthSpriteSection = 64;
        private protected const int InivincibilityFrames = 30;
        private protected bool IsDamaged = false;
        private protected int timeLeftDamage = 100;
        private protected ISprite _texture;
        public Point Position { get; set; }
        public int Health { get; set; } = 6;
        private protected Point velocity;
        private protected Random random;
        private protected bool isActive = true;

        public void KillItem()
        {
            isActive = false;
        }

        public void TakeDamage(int damage)
        {
            if(!IsDamaged)
            {
                IsDamaged = true;
                Health -= damage;
                timeLeftDamage = InivincibilityFrames;
            } 
        }
        public bool IsActive()
        {
            if (Health <= 0) return false;
            return isActive;
        }
        protected void modifyPosition(int dx, int dy)
        {
            Position = new Point(Position.X + dx, Position.Y + dy);
        }
        public abstract Hitbox GetHitBox();
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
