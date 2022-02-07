using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class LeftAttackLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;

        public LeftAttackLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            linkSprite = LinkSpriteFactory.Instance.LinkLeftAttack();

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
            //return to idle after attack
            link.linkState = new LeftIdleLinkState(position, link);
        }

        public void ChangeDirectionRight()
        {
            //Don't do anything besides attacking
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
