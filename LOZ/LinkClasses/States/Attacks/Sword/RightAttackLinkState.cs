using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.GameState;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses.States
{
    class RightAttackLinkState : LinkStateAbstract
    {
        private Point attackPosition;
        public RightAttackLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkRightAttack();
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
            attackPosition.X = position.X + 35;
            attackPosition.Y = position.Y;
            CurrentRoom.Room.gameObjects.Add(new LeftRightSwordHitBox(attackPosition));
        }

    }
}
