using Microsoft.Xna.Framework;
using Sprint2.Factories;
using Sprint2.GameState;
using Sprint2.ItemsClasses;

namespace Sprint2.LinkClasses.States
{ 
    class UpAttackItemLinkState : LinkStateAbstract
    {

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
            //Don't do anything besides attacking
            if (toUse == Weapon.Swordbeam)
            {
                GameObjects.Instance.LinkItems.Add(new SwordBeamUp(position));
            }
            else if (toUse == Weapon.Arrow)
            {
                GameObjects.Instance.LinkItems.Add(new ArrowUpItem(position));
            }
            else if (toUse == Weapon.Bomb)
            {
                GameObjects.Instance.LinkItems.Add(new Bomb(position));
            }
        }

    }
}
