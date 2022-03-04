using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.GameState;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses.States
{ 
    class UpAttackLinkState : LinkStateAbstract
    {
        private Point attackPosition;
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
            attackPosition.X = position.X - 5;
            attackPosition.Y = position.Y - 40;
            CurrentRoom.Instance.Room.gameObjects.Add(new UpDownSwordHitBox(attackPosition));
        }

    }
}
