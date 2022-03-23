using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.GameState;
using LOZ.Collision;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses
{
    
    class DamagedLink : ILink
    {
        private ILink decoratedLink;
        private int count = 15;
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
            this.decoratedLink = decoratedLink;
            CurrentRoom.Instance.Room.Damaged = true;
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
            decoratedLink.KnockBack(vel);
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

        public Point GetPosition()
        {
            return decoratedLink.GetPosition();
        }

        public Hitbox GetHitBox()
        {
            Hitbox hitbox = new Hitbox(Position.X - 48 / 2 + 4, Position.Y - 48 / 2 + 4, 40, 40);
            return hitbox;
        }

        public void Update(GameTime timer)
        {
            count--;
            if(count == 0)
            {
                RemoveDecorator();
            }
            decoratedLink.Update(timer);
        }

        public void RemoveDecorator()
        {
           Room.Link = decoratedLink;
            CurrentRoom.Instance.Room.Damaged = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            decoratedLink.Draw(spriteBatch);

        }

    }
}
