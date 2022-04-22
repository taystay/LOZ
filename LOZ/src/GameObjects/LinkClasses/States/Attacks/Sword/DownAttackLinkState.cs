using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.ItemsClasses;
using LOZ.Sound;
using LOZ.GameStateReference;

namespace LOZ.LinkClasses.States
{
    class DownAttackLinkState : LinkStateAbstract
    {
        private readonly int attackLength = 22;
        private int counter = 0;
        private Point attackPosition;
        public DownAttackLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkDownAttack();
        }
        public override void Down() { }
        public override void Idle()
        {
            if(counter >= attackLength)
                link.LinkState = new DownIdleLinkState(link);
        }
        public override void Attack(Weapon toUse, Point position)
        {
            attackPosition.X = position.X;
            attackPosition.Y = position.Y + 35;
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

