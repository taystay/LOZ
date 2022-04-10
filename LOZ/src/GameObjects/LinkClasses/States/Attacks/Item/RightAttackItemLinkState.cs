using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.GameState;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses.States
{
    class RightAttackItemLinkState : LinkStateAbstract
    {
        private Point attackPosition;
        public RightAttackItemLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkItemRightAttack();
        }
        public override void Idle()
        {
            link.LinkState = new RightIdleLinkState(link);
        }
        public override void Attack(Weapon toUse, Point position)
        {
            attackPosition.X = position.X + 36;
            attackPosition.Y = position.Y;
            //Don't do anything besides attacking
            if (toUse == Weapon.Swordbeam)
            {
                AttemptAttack(new SwordProjectile(attackPosition,1), toUse);
            }
            else if (toUse == Weapon.Arrow)
            {
                AttemptAttack(new ArrowProjectile(attackPosition, 1), toUse);
            }
            else if (toUse == Weapon.Bomb)
            {
                AttemptAttack(new Bomb(attackPosition), toUse);
            }
            else if (toUse == Weapon.Fire)
            {
                attackPosition.X = position.X + 45;
                AttemptAttack(new FireProjectile(attackPosition, Direction.Right), toUse);
            }
            else if (toUse == Weapon.Portal)
            {
                //AttemptAttack(new Portal(attackPosition, 1, PortalManager.getColor()), toUse);
            }
        }

    }
}
