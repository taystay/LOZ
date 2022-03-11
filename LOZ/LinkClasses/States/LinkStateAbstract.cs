using Microsoft.Xna.Framework;
using LOZ.GameState;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.LinkClasses.States;
using LOZ.ItemsClasses;
using LOZ.Collision;

namespace LOZ.LinkClasses
{
    abstract class LinkStateAbstract : ILinkState
    {
        private protected ISprite linkSprite;
        private protected Link link;
        protected static int attackCoolDown = 30;
        protected static int timeSinceAttack = 0;
        protected static bool attackAllowed = true;
        protected int attackXOffSet = 0;
        protected int attackYOffSet = 0;

        public virtual void Up() { }
        public virtual void Down() { }
        public virtual void Left() { }
        public virtual void Right() { }
        public virtual void Move() { }
        public virtual void Idle() { }
        public virtual void Attack(Weapon toUse, Point position) { }
        public virtual void AttemptAttack(IGameObjects weapon)
        {
            if (attackAllowed)
            {
                CurrentRoom.Instance.Room.GameObjects.Add(weapon);
                attackAllowed = false;
                return;
            }
            
            
        }
        public virtual void TakeDamage()
        {
           Room.Link = new DamagedLink(link);
        }
        public virtual void RaiseItem(IItem item)
        {
            link.LinkState = new RaiseItemLinkState(link, item);
        }
        public virtual void Update(GameTime timer)
        {
            if (!attackAllowed)
            {
                timeSinceAttack++;
                if (timeSinceAttack >= attackCoolDown)
                {
                    attackAllowed = true;
                    timeSinceAttack = 0;
                }
            }
                linkSprite.Update(timer);
        }
        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            linkSprite.Draw(spriteBatch, position);
        }

    }
}
