
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.GameState;
using Sprint2.Factories;

namespace Sprint2.LinkClasses.States
{
    class UpIdleLinkState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;

        public UpIdleLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkUpIdle();

        }

        public void Up()
        {
            //Does nothing cause already facing up
        }

        public void Down()
        {
            link.LinkState = new DownIdleLinkState(link);
        }

        public void Left()
        {
            link.LinkState = new LeftIdleLinkState(link);
        }

        public void Right()
        {
            link.LinkState = new RightIdleLinkState(link);
        }

        public void Move()
        {
            link.LinkState = new UpMovingLinkState(link);
        }

        public void Idle()
        {
            //Do nothing already idle
        }

        public void Attack(Weapon toUse, Point position)
        {
            if (toUse == Weapon.Default)
                link.LinkState = new UpAttackLinkState(link);
            else
                link.LinkState = new UpAttackItemLinkState(link);
            link.LinkState.Attack(toUse, position);
        }

        public void TakeDamage()
        {
            GameObjects.Instance.Link = new DamagedLink(link);
        }
        public void Update(GameTime timer)
        {

            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch, Point position)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
