
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.LinkClasses.States
{
    class DownMovingLinkState : LinkStateAbstract
    {
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
            if(!knockedBack)
                link.Position = new Point(link.Position.X, link.Position.Y + moveVelocity);
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
