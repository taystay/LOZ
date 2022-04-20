using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.ItemsClasses;
using LOZ.GameStateReference;

namespace LOZ.LinkClasses.States
{
    class DeadLinkState : LinkStateAbstract
    {
        public DeadLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkDead();
        }
        public override void Up() { }
        public override void Down() { }
        public override void Left() { }
        public override void Right() { }
        public override void Move() { }
        public override void Idle() { }
        public override void Attack(Weapon toUse, Point position) { }
        public override void KnockBack(Point vel) { }
        public override void TakeDamage(int damage) { }
        public override void Die() { }
        public override void RaiseItem(IItem item) { }
        public override void Update(GameTime timer)
        {
            if(RoomReference.GetLink().Health > 0)
            {
                link.LinkState = new DownIdleLinkState(link);
            }
            linkSprite.Update(timer);
        }
    }
}
