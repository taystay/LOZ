
using Microsoft.Xna.Framework; 
using LOZ.Factories;

namespace LOZ.LinkClasses.States
{
    class UpMovingLinkState : LinkStateAbstract
    {
        private const int speed = 4;

        public UpMovingLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingUp();

        }

        public override void Down()
        {
            link.LinkState = new DownIdleLinkState(link);
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
            link.LinkState = new UpIdleLinkState(link);
        }

        public override void Attack(Weapon toUse, Point position)
        {
            if (toUse == Weapon.Default)
                link.LinkState = new UpAttackLinkState(link);
            else
                link.LinkState = new UpAttackItemLinkState(link);
            link.LinkState.Attack(toUse, position);
        }

        public override void Update(GameTime timer)
        {
            link.Position = new Point(link.Position.X, link.Position.Y - speed);
            linkSprite.Update(timer);
        }
    }
}
