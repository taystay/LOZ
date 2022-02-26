
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.LinkClasses.States
{ 
    class UpAttackLinkState : LinkStateAbstract
    {

        public UpAttackLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkUpAttack();
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
        }

    }
}
