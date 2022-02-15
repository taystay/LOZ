
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;

namespace Sprint2.LinkClasses.States

{
    class RightIdleLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;
        private Point attackPosition;

        public RightIdleLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            attackPosition = new Point(position.X + 40, position.Y + 16);
            linkSprite = LinkSpriteFactory.Instance.LinkRightIdle();

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

            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
