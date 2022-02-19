
using Microsoft.Xna.Framework;
using Sprint2.Factories;
using Sprint2.LinkClasses.States;

namespace Sprint2.LinkClasses
{
    class DownIdleLinkState : LinkStateAbstract
    {

        public DownIdleLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkDownIdle();

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

        public override void Move()
        {
            link.LinkState = new DownMovingLinkState(link);
        }

        public override void Attack(Weapon toUse, Point position)
        {
            if (toUse == Weapon.Default)
                link.LinkState = new DownAttackLinkState(link);
            else
                link.LinkState = new DownAttackItemLinkState(link);

            link.LinkState.Attack(toUse, position);
        }

    }
}

