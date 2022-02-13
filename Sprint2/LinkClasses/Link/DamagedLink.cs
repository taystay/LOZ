using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class DamagedLink : ILink
    {
        private ILink decoratedLink;
        private int count = 1000;

        public DamagedLink(ILink decoratedLink)
        {
            this.decoratedLink = decoratedLink;
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

        public void Attack()
        {
            decoratedLink.Attack();
        }

        public void TakeDamage()
        {
            //Already taking damage
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
            GameObjects.Link = decoratedLink;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            decoratedLink.Draw(spriteBatch);

        }

    }
}
