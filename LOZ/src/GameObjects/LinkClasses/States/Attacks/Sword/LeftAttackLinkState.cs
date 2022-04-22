using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses.States
{
    class LeftAttackLinkState : LinkStateAbstract
    {
        private readonly int attackLength = 22;
        private int counter = 0;
        private Point attackPosition;
        public LeftAttackLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkLeftAttack();

        }
        public override void Left() { }
        public override void Idle()
        {
            if (counter >= attackLength)
                link.LinkState = new LeftIdleLinkState(link);
        }
        public override void Attack(Weapon toUse, Point position)
        {
            attackPosition.X = position.X - 40;
            attackPosition.Y = position.Y;
            AttemptAttack(new LeftRightSwordHitBox(attackPosition), toUse);
        }
        public override void Update(GameTime timer)
        {
            NormalUpdate(timer);
            counter++;
            if (counter >= attackLength)
                Idle();
        }
    }
}

