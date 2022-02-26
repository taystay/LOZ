using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.LinkClasses.States
{
    class LeftAttackLinkState : LinkStateAbstract
    {

        public LeftAttackLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkLeftAttack();

        }
        public override void Left()
        {
            //return to idle after attack
            link.LinkState = new LeftIdleLinkState(link);
        }
        public override void Idle()
        {
            link.LinkState = new LeftIdleLinkState(link);
        }

        public override void Attack(Weapon toUse, Point position)
        {
            //Don't do anything besides attacking
        }

    }
}

