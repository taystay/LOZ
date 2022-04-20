
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses.States
{
    class RaiseItemLinkState : LinkStateAbstract
    {
        private int startTime = 0;
        private int endTime = 80;
        private IItem item;
        public RaiseItemLinkState(Link link, IItem item)
        {
            this.link = link;
            this.item = item;
            linkSprite = LinkSpriteFactory.Instance.LinkRaiseItem();
            item.SetPosition(new Point(link.Position.X, link.Position.Y - 50));
        }
        public override void Attack(Weapon toUse, Point position) { }
        public override void Update(GameTime timer)
        {
            linkSprite.Update(timer);
            startTime++;
            if(startTime == endTime)
            {
                item.KillItem();
                link.LinkState = new DownIdleLinkState(link);
            }
        }

    }
}
