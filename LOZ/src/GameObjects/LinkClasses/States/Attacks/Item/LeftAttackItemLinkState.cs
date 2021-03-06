
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.GameState;
using LOZ.ItemsClasses;


namespace LOZ.LinkClasses.States
{
    class LeftAttackItemLinkState : LinkStateAbstract
    {
        private readonly int attackLength = 22;
        private int counter = 0;
        private Point attackPosition;
        public LeftAttackItemLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkItemLeftAttack();
        }
        public override void Idle()
        {
            if (counter >= attackLength)
                link.LinkState = new LeftIdleLinkState(link);
        }
        public override void Attack(Weapon toUse, Point position)
        {
            attackPosition.X = position.X - 36;
            attackPosition.Y = position.Y;
            //Don't do anything besides attacking
            if (toUse == Weapon.Swordbeam)
            {
                AttemptAttack(new SwordProjectile(attackPosition, 3), toUse);
            }
            else if (toUse == Weapon.Arrow)
            {
                AttemptAttack(new ArrowProjectile(attackPosition, 3), toUse);
            }
            else if (toUse == Weapon.Bomb)
            {
                AttemptAttack(new Bomb(attackPosition), toUse);
            }
            else if (toUse == Weapon.Fire)
            {
                attackPosition.X = position.X - 45;
                AttemptAttack(new FireProjectile(attackPosition, Direction.Left), toUse);
            }
            else if (toUse == Weapon.Portal)
            {
                AttemptAttack(new Portal(attackPosition, 3, PortalManager.getColor()), toUse);
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

