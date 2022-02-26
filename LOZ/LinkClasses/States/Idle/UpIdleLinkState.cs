
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.LinkClasses.States
{
    class UpIdleLinkState : LinkStateAbstract
    {

        public UpIdleLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkUpIdle();

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

        public override void Move()
        {
            link.LinkState = new UpMovingLinkState(link);
        }

        public override void Attack(Weapon toUse, Point position)
        {
            if (toUse == Weapon.Default)
                link.LinkState = new UpAttackLinkState(link);
            else
                link.LinkState = new UpAttackItemLinkState(link);
            link.LinkState.Attack(toUse, position);
        }

    }
}
