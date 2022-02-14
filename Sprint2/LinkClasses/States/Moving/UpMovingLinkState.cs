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
        private Point attackPosition;
        private int currentItem;

        public UpMovingLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            attackPosition = new Point(position.X + 12, position.Y - 36);
            currentItem = GameObjects.Instance.HeldItem;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingUp();

        }

        public void Up()
        {
            //Does nothing because already facing Up            
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
            //Nothing, already moving up
        }

        public void Idle()
        {
            link.linkState = new UpIdleLinkState(position, link);
        }

        public void Attack()
        {
            if (currentItem == 1)
            {
                link.linkState = new UpAttackLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new SwordBeamUp(attackPosition, 1));
            } else if (currentItem == 2)
            {
                link.linkState = new UpAttackItemLinkState(position, link);
                GameObjects.Instance.LinkItems.Add(new ArrowUpItem(attackPosition, 1));
            } else if (currentItem == 3)
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
            position.Y -= 4;

            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
