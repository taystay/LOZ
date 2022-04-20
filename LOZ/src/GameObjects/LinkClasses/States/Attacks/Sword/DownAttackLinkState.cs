using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses.States
{
    class DownAttackLinkState : LinkStateAbstract
    {
        private Point attackPosition;
        public DownAttackLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkDownAttack();
        }
        public override void Down() { }
        public override void Idle() =>
            link.LinkState = new DownIdleLinkState(link);
        public override void Attack(Weapon toUse, Point position)
        {
            attackPosition.X = position.X;
            attackPosition.Y = position.Y + 35;
            AttemptAttack(new UpDownSwordHitBox(attackPosition), toUse);
        }
    }
}

