using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class UpIdleLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;
        private Point attackPosition;
        private int currentItem;

        public UpIdleLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            attackPosition = new Point(position.X + 12, position.Y - 36);
            currentItem = GameObjects.Instance.HeldItem;
            linkSprite = LinkSpriteFactory.Instance.LinkUpIdle();

        }

        public void Up()
        {
            //Does nothing cause already facing up
        }

        public void Down()
        {
            link.linkState = new DownIdleLinkState(position, link);
        }

        public void Left()
        {
            link.linkState = new LeftIdleLinkState(position, link);
        }

        public void Right()
        {
            link.linkState = new RightIdleLinkState(position, link);
        }

        public void Move()
        {
            link.linkState = new UpMovingLinkState(position, link);
        }

        public void Idle()
        {
            //Do nothing already idle
        }

        public void Attack()
        {
            if (currentItem == 1)
            {
                link.linkState = new UpAttackLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new SwordBeamUp(attackPosition, 1));
            }
            else if (currentItem == 2)
            {
                link.linkState = new UpAttackItemLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new ArrowUpItem(attackPosition, 1));
            }
            else if (currentItem == 3)
            {
                link.linkState = new UpAttackItemLinkState(position, link);
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
