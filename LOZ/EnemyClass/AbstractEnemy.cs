using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using System;

namespace LOZ.EnemyClass
{
    abstract class AbstractEnemy : IEnemy
    {
        private protected const int HeightSpriteSection = 83;
        private protected const int WidthSpriteSection = 64;
        //private protected int scale;
        private protected ISprite _texture;
        private protected Point position;
        private protected int xPosition;
        private protected int yPosition;
        private protected Random random;

        public abstract Rectangle GetHitBox();
        public abstract void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch)
        {
            _texture.Draw(spriteBatch, position);
        }
    }
}
