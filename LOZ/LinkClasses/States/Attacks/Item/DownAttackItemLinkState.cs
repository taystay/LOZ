﻿using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.GameState;
using LOZ.ItemsClasses;


namespace LOZ.LinkClasses.States
{
    class DownAttackItemLinkState : LinkStateAbstract
    {
        private Point attackPosition;
        public DownAttackItemLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkItemDownAttack();

        }
        public override void Down()
        {
            //return to idle after attack
            link.LinkState = new DownIdleLinkState(link);
        }

        public override void Idle()
        {
            link.LinkState = new DownIdleLinkState(link);
        }

        public override void Attack(Weapon toUse, Point position)
        {
            attackPosition.X = position.X;
            attackPosition.Y = position.Y + 36;
            //Don't do anything besides attacking
            if(toUse == Weapon.Swordbeam)
            {
                AttemptAttack(new SwordBeamDown(attackPosition));
            } else if (toUse == Weapon.Arrow)
            {
                AttemptAttack(new ArrowDownItem(attackPosition));
            } else if (toUse == Weapon.Bomb)
            {
                AttemptAttack(new Bomb(attackPosition));
            } else if (toUse == Weapon.Fire)
            {
                attackPosition.Y = position.Y + 45;
                AttemptAttack(new FireProjectile(attackPosition, Direction.Down));
            }
        }

    }
}

