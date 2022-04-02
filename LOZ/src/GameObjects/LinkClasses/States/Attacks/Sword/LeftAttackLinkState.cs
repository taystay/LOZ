using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses.States
{
    class LeftAttackLinkState : LinkStateAbstract
    {
        private Point attackPosition;
        public LeftAttackLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkLeftAttack();

        }
        public override void Left()
        {
            //return to idle after attack
            //link.LinkState = new LeftIdleLinkState(link);
        }
        public override void Idle()
        {
            link.LinkState = new LeftIdleLinkState(link);
        }

        public override void Attack(Weapon toUse, Point position)
        {
            attackPosition.X = position.X - 40;
            attackPosition.Y = position.Y;
            AttemptAttack(new LeftRightSwordHitBox(attackPosition), toUse);
        }

    }
}

