
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;

namespace Sprint2.LinkClasses.States
{
    class LeftMovingLinkState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;
        private const int speed = 4;

        public LeftMovingLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingLeft();

        }

        public void Up()
        {
            link.LinkState = new UpIdleLinkState(link);
        }

        public void Down()
        {
            link.LinkState = new DownIdleLinkState(link);
        }

        public void Left()
        {
            //Do nothing because already facing left
        }

        public void Right()
        {
            link.LinkState = new RightIdleLinkState(link);
        }

        public void Move()
        {
            //Nothing, already moving left
        }

        public void Idle()
        {
            link.LinkState = new LeftIdleLinkState(link);
        }

        public void Attack(Weapon toUse, Point position)
        {
            if (toUse == Weapon.Default)
                link.LinkState = new LeftAttackLinkState(link);
            else
                link.LinkState = new LeftAttackItemLinkState(link);
            link.LinkState.Attack(toUse, position);
        }

        public void TakeDamage()
        {
            GameObjects.Instance.Link = new DamagedLink(link);
        }

        public void Update(GameTime timer)
        {
            link.Position = new Point(link.Position.X - speed, link.Position.Y);

            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch, Point position)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
