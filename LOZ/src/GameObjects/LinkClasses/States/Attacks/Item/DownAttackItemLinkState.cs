using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Sound;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses.States
{
    class DownAttackItemLinkState : LinkStateAbstract
    {
        private readonly int attackLength = 22;
        private int counter = 0;
        private Point attackPosition;
        public DownAttackItemLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkItemDownAttack();
        }
        public override void Idle()
        {
            if (counter >= attackLength)
                link.LinkState = new DownIdleLinkState(link);
        }
        public override void Attack(Weapon toUse, Point position)
        {
            attackPosition.X = position.X;
            attackPosition.Y = position.Y + 36;
            //Don't do anything besides attacking
            if(toUse == Weapon.Swordbeam)
            {
                AttemptAttack(new SwordProjectile(attackPosition, 2), toUse);
            } else if (toUse == Weapon.Arrow)
            {
                AttemptAttack(new ArrowProjectile(attackPosition, 2), toUse);
            } else if (toUse == Weapon.Bomb)
            {
                AttemptAttack(new Bomb(attackPosition), toUse);
            } else if (toUse == Weapon.Fire)
            {
                attackPosition.Y = position.Y + 45;
                AttemptAttack(new FireProjectile(attackPosition, Direction.Down), toUse);
            } else if (toUse == Weapon.Portal)
            {
                AttemptAttack(new Portal(attackPosition, 2, PortalManager.getColor()), toUse);
            }
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

