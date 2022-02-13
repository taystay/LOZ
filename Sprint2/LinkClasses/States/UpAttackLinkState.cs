using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class UpAttackLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;

        public UpAttackLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            linkSprite = LinkSpriteFactory.Instance.LinkUpAttack();

        }

        public void ChangeDirectionUp()
        {
            //return to idle after attack
            link.linkState = new UpIdleLinkState(position, link);
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
            //Don't do anything besides attacking
        }

        public void Move()
        {
            //Don't do anything besides attacking
        }

        public void Idle()
        {
            link.linkState = new UpIdleLinkState(position, link);
        }

        public void Attack()
        {
            //Don't do anything besides attacking
        }

        public void TakeDamage()
        {
            GameObjects.Link = new DamagedLink(link);
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
