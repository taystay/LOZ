
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;

namespace Sprint2.LinkClasses.States
{
    class RightMovingLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;
        private Point attackPosition;

        public RightMovingLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            attackPosition = new Point(position.X + 40, position.Y + 16);
            linkSprite = LinkSpriteFactory.Instance.LinkMovingRight();

        }

        public void Up()
        {
            link.linkState = new UpIdleLinkState(position, link);
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

        public void Attack(Weapon toUse)
        {
            if (toUse == Weapon.Default)
                link.linkState = new RightAttackLinkState(position, link);
            else
                link.linkState = new RightAttackItemLinkState(position, link);
            link.linkState.Attack(toUse);
        }

        public void TakeDamage()
        {
            GameObjects.Instance.Link = new DamagedLink(link);
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
