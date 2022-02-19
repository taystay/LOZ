using Microsoft.Xna.Framework;
using Sprint2.GameState;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.LinkClasses
{
    abstract class LinkStateAbstract : ILinkState
    {
        private protected ISprite linkSprite;
        private protected Link link;

        public virtual void Up() { }

        public virtual void Down() { }

        public virtual void Left() { }
        public virtual void Right() { }

        public virtual void Move() { }
        public virtual void Idle() { }

        public abstract void Attack(Weapon toUse, Point position);
        public virtual void TakeDamage()
        {
            GameObjects.Instance.Link = new DamagedLink(link);
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
