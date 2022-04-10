using Microsoft.Xna.Framework;
using LOZ.Room;
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
        #region privates
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
        protected static Point knockBackVel = new Point(0, 0);
        #endregion 

        public virtual void Up() { }
        public virtual void Down() { }
        public virtual void Left() { }
        public virtual void Right() { }
        public virtual void Move() { }
        public virtual void Idle() { }
        public virtual void Attack(Weapon toUse, Point position) { }
        public virtual void AttemptAttack(IGameObjects weapon, Weapon type)
        {
            if (attackAllowed) 
            {
                if (type == Weapon.Default)
                {
                    SoundManager.Instance.SoundToPlayInstance(SoundEnum.Sword_Slash);
                    timeSinceAttack = attackCoolDown;
                }
                else if (type == Weapon.Swordbeam)
                    SoundManager.Instance.SoundToPlayInstance(SoundEnum.Sword_Shoot);
                else if (type == Weapon.Arrow)
                    SoundManager.Instance.SoundToPlayInstance(SoundEnum.Sword_Shoot);
                else if (type == Weapon.Fire)
                    SoundManager.Instance.SoundToPlayInstance(SoundEnum.Sword_Combined);
                else if (type == Weapon.Portal)
                {
                    //PortalManager.AddPortal((Portal)weapon);
                    SoundManager.Instance.SoundToPlayInstance(SoundEnum.PortalShot);
                }

                //CurrentRoom.Instance.Room.GameObjects.Add(weapon);
                CurrentRoom.Instance.AddItemToRoom(weapon);

                if (TypeC.Check(weapon, typeof(Bomb))) Room.RoomInventory.UseBomb();
                if (type == Weapon.Arrow) Room.RoomInventory.UseRupee();
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
           CurrentRoom.link = new DamagedLink(link, damage);
        }
        public virtual void Die()
        {
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Link_Die);
            link.LinkState = new DeadLinkState(link);
        }
        public virtual void RaiseItem(IItem item)
        {
            if (TypeC.Check(item, typeof(Triforce)))
                link.LinkState = new RaiseItemLinkState(link, item);
            else
            {
                item.KillItem();
            }
            if(TypeC.Check(item, typeof(Fairy)))
            {
                CurrentRoom.link.Health += 3;
            }    
            if(TypeC.Check(item, typeof(HeartContainer)))
            {
                CurrentRoom.link.MaxHealth += 2;
            }
            else if (TypeC.Check(item, typeof(Heart)))
            {
                CurrentRoom.link.Health += 2;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Get_Heart);
            }
        }
        public virtual void Update(GameTime timer)
        {
            if (CurrentRoom.link.Health > 2)
            {
                SoundManager.Instance.SoundToNotLoop(SoundEnum.LowHealth);
            }
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
