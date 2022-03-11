using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.ItemsClasses
{
    abstract class IPlayerProjectile : IItem
    {
        private protected ISprite sprite;
        public Point _itemLocation { get; set; }
        private protected bool spriteActivity = true;
        private protected int hitBoxWidth = 2;
        private protected int hitBoxHeight = 2;
        public int Damage { get; set; } = 0;
        public void SetPosition(Point position)
        {
            _itemLocation = position;
        }
        public bool SpriteActive()
        {
            return spriteActivity;
        }
        public virtual void KillItem()
        {
            spriteActivity = false;
        }
        public virtual Hitbox GetHitBox()
        {
            Hitbox hitbox = new Hitbox(_itemLocation.X - hitBoxWidth / 2, _itemLocation.Y - hitBoxHeight / 2, hitBoxWidth, hitBoxHeight);
            return hitbox;
        }
        public abstract void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, _itemLocation);
        }
    }
}
