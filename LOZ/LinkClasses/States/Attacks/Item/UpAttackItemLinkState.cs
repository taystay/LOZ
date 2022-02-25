using Microsoft.Xna.Framework;
using Sprint2.Factories;
using Sprint2.GameState;
using Sprint2.ItemsClasses;

namespace Sprint2.LinkClasses.States
{ 
    class UpAttackItemLinkState : LinkStateAbstract
    {
        private Point attackPosition;
        public UpAttackItemLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkItemUpAttack();

        }
        public override void Up()
        {
            //return to idle after attack
            link.LinkState = new UpIdleLinkState(link);
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
                GameObjects.Instance.LinkItems.Add(new SwordBeamUp(attackPosition));
            }
            else if (toUse == Weapon.Arrow)
            {
                GameObjects.Instance.LinkItems.Add(new ArrowUpItem(attackPosition));
            }
            else if (toUse == Weapon.Bomb)
            {
                GameObjects.Instance.LinkItems.Add(new Bomb(attackPosition));
            }
            else if (toUse == Weapon.Fire)
            {
                GameObjects.Instance.LinkItems.Add(new FireProjectile(attackPosition, Direction.Up));
            }
        }

    }
}
