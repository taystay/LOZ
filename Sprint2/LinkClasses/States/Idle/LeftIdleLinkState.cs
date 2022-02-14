using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class LeftIdleLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;
        private Point attackPosition;
        private int currentItem;

        public LeftIdleLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            attackPosition = new Point(position.X - 36, position.Y + 20);
            currentItem = GameObjects.Instance.HeldItem;
            linkSprite = LinkSpriteFactory.Instance.LinkLeftIdle();

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
            //Nothing, already facing left
        }

        public void ChangeDirectionRight()
        {
            link.linkState = new RightIdleLinkState(position, link);
        }

        public void Move()
        {
            link.linkState = new LeftMovingLinkState(position, link);
        }

        public void Idle()
        {
            //Do nothing already idle
        }

        public void Attack()
        {
            if (currentItem == 1)
            {
                link.linkState = new LeftAttackLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new SwordBeamLeft(attackPosition, 1));
            }
            else if (currentItem == 2)
            {
                link.linkState = new LeftAttackItemLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new ArrowLeftItem(attackPosition, 1));
            }
            else if (currentItem == 3)
            {
                link.linkState = new LeftAttackItemLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new Bomb(attackPosition, 1));
            }
        }

        public void TakeDamage()
        {
            GameObjects.Instance.Link = new DamagedLink(link);
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
