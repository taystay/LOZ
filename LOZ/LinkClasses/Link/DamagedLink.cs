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
        public Point Position { get; set; }

        public DamagedLink(ILink decoratedLink)
        {
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

        public void TakeDamage()
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
            CurrentRoom.Instance.Room.Link = decoratedLink;
            CurrentRoom.Instance.Room.Damaged = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            decoratedLink.Draw(spriteBatch);

        }

    }
}
