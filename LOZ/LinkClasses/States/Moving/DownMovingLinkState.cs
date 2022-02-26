
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.LinkClasses.States
{
    class DownMovingLinkState : LinkStateAbstract
    {
        private const int speed = 4;

        public DownMovingLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingDown();

        }
        public override void Up()
        {
            link.LinkState = new UpIdleLinkState(link);
        }
        public override void Left()
        {
            link.LinkState = new LeftIdleLinkState(link);
        }

        public override void Right()
        {
            link.LinkState = new RightIdleLinkState(link);
        }

        public override void Idle()
        {
            link.LinkState = new DownIdleLinkState(link);
        }

        public override void Attack(Weapon toUse, Point position)
        {
            if (toUse == Weapon.Default)
                link.LinkState = new DownAttackLinkState(link);
            else
                link.LinkState = new DownAttackItemLinkState(link);
            link.LinkState.Attack(toUse, position);
        }

        public override void Update(GameTime timer)
        {
            link.Position = new Point(link.Position.X, link.Position.Y + speed);
            linkSprite.Update(timer);
        }

    }
}
