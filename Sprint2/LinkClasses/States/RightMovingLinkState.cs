using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class RightMovingLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;

        public RightMovingLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingRight();

        }

        public void ChangeDirectionUp()
        {
            link.linkState = new UpIdleLinkState(position, link);
        }

        public void ChangeDirectionDown()
        {
            link.linkState = new DownIdleLinkState(position, link);
        }

        public void ChangeDirectionLeft()
        {
            link.linkState = new LeftIdleLinkState(position, link);
        }

        public void ChangeDirectionRight()
        {
            //Does nothing because already facing right
        }

        public void Move()
        {
            //Nothing, already moving right
        }

        public void Idle()
        {
            link.linkState = new RightIdleLinkState(position, link);
        }

        public void Attack()
        {
            link.linkState = new RightAttackLinkState(position, link);
        }

        public void TakeDamage()
        {
            GameObjects.Link = new DamagedLink(link);
        }

        public void Update(GameTime timer)
        {
            position.X += 4;

            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
