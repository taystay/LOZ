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
                CurrentRoom.Instance.Room.GameObjects.Add(new SwordBeamUp(attackPosition));
            }
            else if (toUse == Weapon.Arrow)
            {
                CurrentRoom.Instance.Room.GameObjects.Add(new ArrowUpItem(attackPosition));
            }
            else if (toUse == Weapon.Bomb)
            {
                CurrentRoom.Instance.Room.GameObjects.Add(new Bomb(attackPosition));
            }
            else if (toUse == Weapon.Fire)
            {
                attackPosition.Y = position.Y - 45;
                CurrentRoom.Instance.Room.GameObjects.Add(new FireProjectile(attackPosition, Direction.Up));
            }
        }

    }
}
