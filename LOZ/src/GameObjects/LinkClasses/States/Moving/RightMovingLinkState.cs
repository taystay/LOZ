
using Microsoft.Xna.Framework;
using LOZ.Factories;


namespace LOZ.LinkClasses.States
{
    class RightMovingLinkState : LinkStateAbstract
    {
        public RightMovingLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingRight();
        }
        public override void Up() =>
            link.LinkState = new UpIdleLinkState(link);
        public override void Down() =>
            link.LinkState = new DownIdleLinkState(link);
        public override void Left() =>
            link.LinkState = new LeftIdleLinkState(link);
        public override void Idle() =>
            link.LinkState = new RightIdleLinkState( link);
        public override void Attack(Weapon toUse, Point position)
        {
            if (toUse == Weapon.Default)
                link.LinkState = new RightAttackLinkState(link);
            else
                link.LinkState = new RightAttackItemLinkState(link);
            link.LinkState.Attack(toUse, position);
        }
        public override void Update(GameTime timer)
        {
            if (!knockedBack)
                link.Position = new Point(link.Position.X + moveVelocity, link.Position.Y);
            else
            {
                currentKnockBack++;
                if (currentKnockBack >= knockBackDuration)
                {
                    knockedBack = false;
                    currentKnockBack = 0;
                }
                else
                {
                    link.Position = new Point(link.Position.X + knockBackVel.X, link.Position.Y + knockBackVel.Y);
                }
            }
            linkSprite.Update(timer);
        }

    }
}
