using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class DownIdleLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;

        public DownIdleLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            linkSprite = LinkSpriteFactory.Instance.LinkDownIdle();

        }

        public void ChangeDirectionUp()
        {
            link.linkState = new UpIdleLinkState(position, link);
        }

        public void ChangeDirectionDown()
        {
            //Does nothing because already facing down
        }

        public void ChangeDirectionLeft()
        {
            link.linkState = new LeftIdleLinkState(position, link);
        }

        public void ChangeDirectionRight()
        {
            link.linkState = new RightIdleLinkState(position, link);
        }

        public void Move()
        {
            link.linkState = new DownMovingLinkState(position, link);
        }

        public void Idle()
        {
            //Do nothing already idle
        }

        public void Attack()
        {
            link.linkState = new DownAttackLinkState(position, link);
        }

        public void TakeDamage()
        {
            //link.linkState = new DamagedLink(link.linkState);
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
