using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;

namespace LOZ.ItemsClasses
{
    abstract class ItemAbstract : IItem
    {
        private protected ISprite sprite;
        private protected Point _itemLocation;
        private protected bool spriteActivity = true;
        private protected int hitBoxWidth = 2;
        private protected int hitBoxHeight = 2;

        public bool SpriteActive()
        {
            return spriteActivity;
        }

        public Rectangle GetHitBox()
        {
            Rectangle hitbox = new Rectangle(_itemLocation.X - hitBoxWidth / 2, _itemLocation.Y - hitBoxHeight / 2, hitBoxWidth, hitBoxHeight);
            return hitbox;
        }

        public abstract void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, _itemLocation);
        }



    }
}
