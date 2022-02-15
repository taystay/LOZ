
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;
using Sprint2.LinkClasses.States;

namespace Sprint2.LinkClasses
{
    class DownIdleLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;
        private Point attackPosition;

        public DownIdleLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            attackPosition = new Point(position.X + 18, position.Y + 36);
            linkSprite = LinkSpriteFactory.Instance.LinkDownIdle();

        }

        public void Up()
        {
            link.linkState = new UpIdleLinkState(position, link);
        }

        public void Down()
        {
            //Does nothing because already facing down
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
            link.linkState = new DownMovingLinkState(position, link);
        }

        public void Idle()
        {
            //Do nothing already idle
        }

        public void Attack(Weapon toUse)
        {
            if (toUse == Weapon.Default)
                link.linkState = new DownAttackLinkState(position, link);
            else
                link.linkState = new DownAttackItemLinkState(position, link);

            link.linkState.Attack(toUse);
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

