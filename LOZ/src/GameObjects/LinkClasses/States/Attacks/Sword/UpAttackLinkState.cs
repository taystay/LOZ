using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses.States
{ 
    class UpAttackLinkState : LinkStateAbstract
    {
        private readonly int attackLength = 22;
        private int counter = 0;
        private Point attackPosition;
        public UpAttackLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkUpAttack();
        }
        public override void Up() { }
        public override void Idle()
        {
            if (counter >= attackLength)
                link.LinkState = new UpIdleLinkState(link);
        }
        public override void Attack(Weapon toUse, Point position)
        {
            attackPosition.X = position.X - 5;
            attackPosition.Y = position.Y - 40;
            AttemptAttack(new UpDownSwordHitBox(attackPosition), toUse);
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
