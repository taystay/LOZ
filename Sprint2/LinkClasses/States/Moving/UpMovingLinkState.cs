
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.GameState;
using Sprint2.Factories;

namespace Sprint2.LinkClasses.States
{
    class UpMovingLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;
        private Point attackPosition;

        public UpMovingLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
            attackPosition = new Point(position.X + 12, position.Y - 36);
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

        public void Attack(Weapon toUse)
        {
            if (toUse == Weapon.Default)
                link.linkState = new UpAttackLinkState(position, link);
            else
                link.linkState = new UpAttackItemLinkState(position, link);
            link.linkState.Attack(toUse);
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
