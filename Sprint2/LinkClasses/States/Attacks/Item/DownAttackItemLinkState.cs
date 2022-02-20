using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;
using Sprint2.ItemsClasses;


namespace Sprint2.LinkClasses.States
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
                GameObjects.Instance.LinkItems.Add(new SwordBeamDown(attackPosition));
            } else if (toUse == Weapon.Arrow)
            {
                GameObjects.Instance.LinkItems.Add(new ArrowDownItem(attackPosition));
            } else if (toUse == Weapon.Bomb)
            {
                GameObjects.Instance.LinkItems.Add(new Bomb(attackPosition));
            }
        }

    }
}

