
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.LinkClasses.States
{
    class RightAttackLinkState : LinkStateAbstract
    {
        public RightAttackLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkRightAttack();
        }

        public override void Right()
        {
            //return to idle after attack
            link.LinkState = new RightIdleLinkState(link);
        }

        public override void Idle()
        {
            link.LinkState = new RightIdleLinkState(link);
        }

        public override void Attack(Weapon toUse, Point position)
        {
            //Don't do anything besides attacking
        }

    }
}
