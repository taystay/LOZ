﻿using Microsoft.Xna.Framework;
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
        public override void Right()
        {
            //return to idle after attack
            link.LinkState = new RightIdleLinkState(link);
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
                GameObjects.Instance.LinkItems.Add(new SwordBeamRight(attackPosition));
            }
            else if (toUse == Weapon.Arrow)
            {
                GameObjects.Instance.LinkItems.Add(new ArrowRightItem(attackPosition));
            }
            else if (toUse == Weapon.Bomb)
            {
                GameObjects.Instance.LinkItems.Add(new Bomb(attackPosition));
            }
            else if (toUse == Weapon.Fire)
            {
                GameObjects.Instance.LinkItems.Add(new FireProjectile(attackPosition, Direction.Right));
            }
        }

    }
}
