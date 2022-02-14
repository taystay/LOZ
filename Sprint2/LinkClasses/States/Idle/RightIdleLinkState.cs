using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class RightIdleLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;
        private Point attackPosition;
        private int currentItem;

        public RightIdleLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            attackPosition = new Point(position.X + 40, position.Y + 16);
            currentItem = GameObjects.Instance.HeldItem;
            linkSprite = LinkSpriteFactory.Instance.LinkRightIdle();

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
            //Nothing, already facing right
        }

        public void Move()
        {
            link.linkState = new RightMovingLinkState(position, link);
        }

        public void Idle()
        {
            //Do nothing already idle
        }

        public void Attack()
        {
            if (currentItem == 1)
            {
                link.linkState = new RightAttackLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new SwordBeamRight(attackPosition, 1));
            }
            else if (currentItem == 2)
            {
                link.linkState = new RightAttackItemLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new ArrowRightItem(attackPosition, 1));
            }
            else if (currentItem == 3)
            {
                link.linkState = new RightAttackItemLinkState(position, link);
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
