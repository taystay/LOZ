using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.LinkClasses.States
{
    class DownAttackLinkState : LinkStateAbstract
    {
        public DownAttackLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkDownAttack();
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
            //Don't do anything besides attacking
        }
 

    }
}

