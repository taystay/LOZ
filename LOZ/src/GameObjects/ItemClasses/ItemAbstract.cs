using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.ItemsClasses
{
    abstract class ItemAbstract : IItem
    {
        public bool InventoryItem { get; set; } = false;
        private protected ISprite sprite;
        private protected Point _itemLocation;
        private protected bool spriteActivity =  true;
        private protected bool needsPositionUpdate = false;
        private protected Point newPos;
        private protected int hitBoxWidth = 14;
        private protected int hitBoxHeight = 34;
        public void SetPosition(Point position)
        {
            _itemLocation = position;
        }
        public void SetPositionOnUpdate(Point position)
        {
            needsPositionUpdate = true;
            newPos = position;
        }

        private protected void UpdatePosition()
        {
            if (needsPositionUpdate && newPos != null)
            {
                _itemLocation = newPos;
                needsPositionUpdate = false;
            }
        }

        public bool SpriteActive()
        {
            return spriteActivity;
        }
        public void KillItem()
        {
            spriteActivity = false;
        }
        public Hitbox GetHitBox()
        {
            Hitbox hitbox = new Hitbox(_itemLocation.X - hitBoxWidth / 2, _itemLocation.Y - hitBoxHeight / 2, hitBoxWidth, hitBoxHeight);
            return hitbox;
        }
        public abstract void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, _itemLocation);
        }

        public void Draw(SpriteBatch spriteBatch, Point offset)
        {
            sprite.Draw(spriteBatch, _itemLocation + offset);
        }
    }
}
