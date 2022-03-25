using Microsoft.Xna.Framework;
using LOZ.GameState;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.LinkClasses.States;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.Sound;

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
        protected int moveVelocity = 4;
        protected static int knockBackDuration = 20;
        protected static int currentKnockBack = 0;
        protected static bool knockedBack = false;
        public Point knockBackVel = new Point(0, 0);

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
                if (TypeC.Check(weapon, typeof(Bomb))) Room.RoomInventory.UseBomb();
                attackAllowed = false;
                return;
            }
        }
        public virtual void KnockBack(Point vel)
        {
            if(!knockedBack)
            {
                knockedBack = true;
                knockBackVel = vel;
                return;
            }
        }
        public virtual void TakeDamage(int damage)
        {
           Room.Link = new DamagedLink(link, damage);
        }
        public virtual void RaiseItem(IItem item)
        {
            link.LinkState = new RaiseItemLinkState(link, item);
            if(TypeC.Check(item, typeof(HeartContainer)))
            {
                Room.Link.MaxHealth += 2;
            }
            else if (TypeC.Check(item, typeof(Heart)))
            {
                Room.Link.Health += 2;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Heart);

                if (Room.Link.Health > 2) {
                    SoundManager.Instance.SoundToNotLoop(SoundEnum.LowHealth);
                }
            }
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
            if (knockedBack)
            {
                currentKnockBack++;
                if(currentKnockBack >= knockBackDuration)
                {
                    knockedBack = false;
                    currentKnockBack = 0;
                } 
                else
                {
                    link.Position = new Point(link.Position.X + knockBackVel.X, link.Position.Y + knockBackVel.Y);
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
