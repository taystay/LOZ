using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint2
{
    class DownMovingLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;
        private Point attackPosition;
        private int currentItem;

        public DownMovingLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            attackPosition = new Point(position.X + 18, position.Y + 36);
            currentItem = GameObjects.Instance.HeldItem;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingDown();

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
            //Nothing, already moving down
        }

        public void Idle()
        {
            link.linkState = new DownIdleLinkState(position, link);
        }

        public void Attack()
        {
            if (currentItem == 1)
            {
                link.linkState = new DownAttackLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new SwordBeamDown(attackPosition, 1));
            }
            else if (currentItem == 2)
            {
                link.linkState = new DownAttackItemLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new ArrowDownItem(attackPosition, 1));
            }
            else if (currentItem == 3)
            {
                link.linkState = new DownAttackItemLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new Bomb(attackPosition, 1));
            }
        }

        public void TakeDamage()
        {
            GameObjects.Instance.Link = new DamagedLink(link);
        }

        public void Update(GameTime timer)
        {
            position.Y += 4;
            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
