using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.ItemsClasses;
using LOZ.GameState;

namespace LOZ.LinkClasses.States
{
    class DeadLinkState : LinkStateAbstract
    {
        public DeadLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkDead();
        }
        public override void Up()
        {
            //Link is dead.
        }
        public override void Down()
        {
            //Link is dead.
        }
        public override void Left()
        {
            //Link is dead.
        }
        public override void Right()
        {
            //Link is dead.
        }
        public override void Move()
        {
            //Link is dead.
        }
        public override void Idle()
        {
            //Link is dead.
        }
        public override void Attack(Weapon toUse, Point position) 
        {
            //Link is dead.
        }
        public override void KnockBack(Point vel)
        {
            //Link is dead.
        }
        public override void TakeDamage(int damage)
        {
            //Link is dead.
        }
        public override void Die()
        {
            //Link is dead.
        }
        public override void RaiseItem(IItem item)
        {
            //Link is dead.
        }
        public override void Update(GameTime timer)
        {
            if(Room.Link.Health > 0)
            {
                link.LinkState = new DownIdleLinkState(link);
            }
            linkSprite.Update(timer);
        }
    }
}
