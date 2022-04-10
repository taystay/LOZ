using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.GameState;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses.States
{ 
    class UpAttackItemLinkState : LinkStateAbstract
    {
        private Point attackPosition;
        public UpAttackItemLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkItemUpAttack();

        }
        public override void Idle()
        {
            link.LinkState = new UpIdleLinkState(link);
        }
        public override void Attack(Weapon toUse, Point position)
        {
            attackPosition.X = position.X;
            attackPosition.Y = position.Y - 48;
;            //Don't do anything besides attacking
            if (toUse == Weapon.Swordbeam)
            {
                AttemptAttack(new SwordProjectile(attackPosition, 0), toUse);
            }
            else if (toUse == Weapon.Arrow)
            {
                AttemptAttack(new ArrowProjectile(attackPosition, 0), toUse);
            }
            else if (toUse == Weapon.Bomb)
            {
                AttemptAttack(new Bomb(attackPosition), toUse);
            }
            else if (toUse == Weapon.Fire)
            {
                attackPosition.Y = position.Y - 45;
                AttemptAttack(new FireProjectile(attackPosition, Direction.Up), toUse);
            }
            else if (toUse == Weapon.Portal)
            {
                //AttemptAttack(new Portal(attackPosition, 0, PortalManager.getColor()), toUse);
            }
        }

    }
}
