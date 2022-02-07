using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class UpMovingLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;

        public UpMovingLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingUp();

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

        public void Move(GameTime timer)
        {
            //Nothing, already moving up
        }

        public void Attack()
        {
            //Nothing here yet
        }

        public void Update(GameTime timer)
        {
            while(position.Y != 0)
                position.Y -= 4;

            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
