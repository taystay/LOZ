using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.GameState;

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
            TestingRoom.Instance.Damaged = true;
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

        public Rectangle GetHitBox()
        {
            Rectangle hitbox = new Rectangle(Position.X, Position.Y, 16, 16);
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
            TestingRoom.Instance.Link = decoratedLink;
            TestingRoom.Instance.Damaged = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            decoratedLink.Draw(spriteBatch);

        }

    }
}
