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
        private protected ISprite _texture;
        public Point Position { get; set; }
        private protected Point velocity;
        private protected Random random;
        private protected bool isActive = true;

        public void KillItem()
        {
            isActive = false;
        }
        public bool IsActive()
        {
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
            _texture.Draw(spriteBatch, Position);
        }
    }
}
