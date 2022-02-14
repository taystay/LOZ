﻿using System;
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
            linkState.Up();
        }

        public void ChangeDirectionDown()
        {
            linkState.Down();
        }

        public void ChangeDirectionLeft()
        {
            linkState.Left();
        }

        public void ChangeDirectionRight()
        {
            linkState.Right();
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

        public void TakeDamage()
        {
            linkState.TakeDamage();
        }

        public Point GetPosition()
        {
            return position;
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
