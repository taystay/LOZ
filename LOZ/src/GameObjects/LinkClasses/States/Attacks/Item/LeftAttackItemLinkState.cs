﻿
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.GameState;
using LOZ.ItemsClasses;


namespace LOZ.LinkClasses.States
{
    class LeftAttackItemLinkState : LinkStateAbstract
    {
        private Point attackPosition;
        public LeftAttackItemLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkItemLeftAttack();

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
            attackPosition.X = position.X - 36;
            attackPosition.Y = position.Y;
            //Don't do anything besides attacking
            if (toUse == Weapon.Swordbeam)
            {
                AttemptAttack(new SwordBeamLeft(attackPosition));
            }
            else if (toUse == Weapon.Arrow)
            {
                AttemptAttack(new ArrowLeftItem(attackPosition));
            }
            else if (toUse == Weapon.Bomb)
            {
                AttemptAttack(new Bomb(attackPosition));
            }
            else if (toUse == Weapon.Fire)
            {
                attackPosition.X = position.X - 45;
                AttemptAttack(new FireProjectile(attackPosition, Direction.Left));
            }
        }

    }
}
