﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class RightAttackLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;

        public RightAttackLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            linkSprite = LinkSpriteFactory.Instance.LinkRightAttack();

        }

        public void ChangeDirectionUp()
        {
            //Don't do anything besides attacking
        }

        public void ChangeDirectionDown()
        {
            //Don't do anything besides attacking
        }

        public void ChangeDirectionLeft()
        {
            //Don't do anything besides attacking
        }

        public void ChangeDirectionRight()
        {
            //return to idle after attack
            link.linkState = new RightIdleLinkState(position, link);
        }

        public void Move(GameTime timer)
        {
            //Don't do anything besides attacking
        }

        public void Attack()
        {
            //Don't do anything besides attacking
        }

        public void Update(GameTime timer)
        {

            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
