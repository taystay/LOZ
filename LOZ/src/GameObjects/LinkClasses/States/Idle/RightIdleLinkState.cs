
using Microsoft.Xna.Framework;
using LOZ.Factories;


namespace LOZ.LinkClasses.States

{
    class RightIdleLinkState : LinkStateAbstract
    {

        public RightIdleLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkRightIdle();
        }
        public override void Up() =>
            link.LinkState = new UpIdleLinkState(link);
        public override void Down() =>
            link.LinkState = new DownIdleLinkState(link);
        public override void Left() =>
            link.LinkState = new LeftIdleLinkState(link);
        public override void Move() =>
            link.LinkState = new RightMovingLinkState(link);
        public override void Attack(Weapon toUse, Point position)
        {
            if (toUse == Weapon.Default)
                link.LinkState = new RightAttackLinkState(link);
            else
                link.LinkState = new RightAttackItemLinkState(link);
            link.LinkState.Attack(toUse, position);
        }

    }
}
