using Microsoft.Xna.Framework;
using LOZ.GameState;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;

namespace LOZ.LinkClasses
{
    abstract class LinkStateAbstract : ILinkState
    {
        private protected ISprite linkSprite;
        private protected Link link;
        private int hitBoxWidth = 16;
        private int hitBoxHeight = 16;

        public virtual void Up() { }
        public virtual void Down() { }
        public virtual void Left() { }
        public virtual void Right() { }
        public virtual void Move() { }
        public virtual void Idle() { }
        public abstract void Attack(Weapon toUse, Point position);
        public virtual void TakeDamage()
        {
            /*
             * 
             */
            TestingRoom.Instance.Link = new DamagedLink(link);
        }
        public Rectangle GetHitBox()
        {
            Rectangle hitbox = new Rectangle(link.Position.X - hitBoxWidth / 2, link.Position.Y - hitBoxHeight / 2, hitBoxWidth, hitBoxHeight);
            return hitbox;
        }
        public virtual void Update(GameTime timer)
        {
            linkSprite.Update(timer);
        }
        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            linkSprite.Draw(spriteBatch, position);
        }








    }
}
