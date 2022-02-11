using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Link : ILink
    {
        private Point position;
        public ILinkState linkState;

        public Link(Point location)
        {

            position = location;
            linkState = new DownIdleLinkState(position, this);

        }
        public void ChangeDirectionUp()
        {
            linkState.ChangeDirectionUp();
        }

        public void ChangeDirectionDown()
        {
            linkState.ChangeDirectionDown();
        }

        public void ChangeDirectionLeft()
        {
            linkState.ChangeDirectionLeft();
        }

        public void ChangeDirectionRight()
        {
            linkState.ChangeDirectionRight();
        }

        public void Move()
        {
            linkState.Move();
        }

        public void Idle()
        {
            linkState.Idle();
        }

        public void Attack()
        {
            linkState.Attack();
        }

        public void Update(GameTime timer)
        {

            linkState.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            linkState.Draw(spriteBatch);

        }

    }
}
