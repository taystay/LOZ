
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;
using Sprint2.LinkClasses.States;

namespace Sprint2.LinkClasses
{
    class DownIdleLinkState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;

        public DownIdleLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkDownIdle();

        }

        public void Up()
        {
            link.LinkState = new UpIdleLinkState(link);
        }

        public void Down()
        {
            //Does nothing because already facing down
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
            link.LinkState = new DownMovingLinkState(link);
        }

        public void Idle()
        {
            //Do nothing already idle
        }

        public void Attack(Weapon toUse, Point position)
        {
            if (toUse == Weapon.Default)
                link.LinkState = new DownAttackLinkState(link);
            else
                link.LinkState = new DownAttackItemLinkState(link);

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

