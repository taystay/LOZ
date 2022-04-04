using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.GameState;
using LOZ.Collision;
using LOZ.ItemsClasses;
using LOZ.Sound;

namespace LOZ.LinkClasses
{
    
    class DamagedLink : ILink
    {
        private ILink decoratedLink;
        private int count = 60;
        public Point Position
        {
            get
            {
                return decoratedLink.Position;
            }
            set
            {
                decoratedLink.Position = value;
            }
        }
        public int Health
        {
            get
            { 
                return decoratedLink.Health;
            }
            set
            {
                decoratedLink.Health = value;
            }
        }
        public int MaxHealth
        {
            get
            {
                return decoratedLink.MaxHealth;
            }
            set
            {
                decoratedLink.MaxHealth = value;
            }
        }
        public DamagedLink(ILink decoratedLink, int damage)
        {
            Room.Link.Health -= damage;
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Link_Hurt);
            this.decoratedLink = decoratedLink;
            Room.Damaged = true;

            if (Room.Link.Health <= 2 && Room.Link.Health > 0)
            {
                SoundManager.Instance.SoundToLoop(SoundEnum.LowHealth);
            }
            if(Room.Link.Health <= 0)
            {
                SoundManager.Instance.SoundToNotLoop(SoundEnum.LowHealth);
                decoratedLink.Die();
            }
        }
        public void ChangeDirectionUp()
        {
            decoratedLink.ChangeDirectionUp();
        }
        public void ChangeDirectionDown()
        {
            decoratedLink.ChangeDirectionDown();
        }
        public void ChangeDirectionLeft()
        {
            decoratedLink.ChangeDirectionLeft();
        }
        public void ChangeDirectionRight()
        {
            decoratedLink.ChangeDirectionRight();
        }
        public void Move()
        {
            decoratedLink.Move();
        }
        public void KnockBack(Point vel)
        {
            //Should not be knocked back while taking damage
        }
        public void Idle()
        {
            decoratedLink.Idle();
        }
        public void RaiseItem(IItem item)
        {
            decoratedLink.RaiseItem(item);
        }
        public void Attack(Weapon currentUse)
        {
            decoratedLink.Attack(currentUse);
        }
        public void TakeDamage(int damage)
        {
            //Already taking damage
        }
        public void Die()
        {
            decoratedLink.Die();
        }
        public Point GetPosition()
        {
            return decoratedLink.GetPosition();
        }

        public void ChangePosition(Point p)
        {
            decoratedLink.ChangePosition(p);
        }
        public Hitbox GetHitBox()
        {
            Hitbox hitbox = new Hitbox(Position.X - 48 / 2 + 14, Position.Y - 48 / 2 + 14, 20, 20);
            return hitbox;
        }
        public void Update(GameTime timer)
        {
            count--;
            if(count <= 0)
            {
                RemoveDecorator();
            }
            decoratedLink.Update(timer);
        }
        public void RemoveDecorator()
        {
           Room.Link = decoratedLink;
           Room.Damaged = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            decoratedLink.Draw(spriteBatch);
        }
    }
}
