using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class LeftMovingLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;
        private Point attackPosition;
        private int currentItem;

        public LeftMovingLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            attackPosition = new Point(position.X - 36, position.Y + 20);
            currentItem = GameObjects.Instance.HeldItem;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingLeft();

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
            //Do nothing because already facing left
        }

        public void ChangeDirectionRight()
        {
            link.linkState = new RightIdleLinkState(position, link);
        }

        public void Move()
        {
            //Nothing, already moving left
        }

        public void Idle()
        {
            link.linkState = new LeftIdleLinkState(position, link);
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
            position.X -= 4;

            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
