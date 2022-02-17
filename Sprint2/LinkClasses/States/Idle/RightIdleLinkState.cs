
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;

namespace Sprint2.LinkClasses.States

{
    class RightIdleLinkState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;

        public RightIdleLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkRightIdle();

        }

        public void Up()
        {
            link.LinkState = new UpIdleLinkState(link);
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
            //Nothing, already facing right
        }

        public void Move()
        {
            link.LinkState = new RightMovingLinkState(link);
        }

        public void Idle()
        {
            //Do nothing already idle
        }

        public void Attack(Weapon toUse, Point position)
        {
            if (toUse == Weapon.Default)
                link.LinkState = new RightAttackLinkState(link);
            else
                link.LinkState = new RightAttackItemLinkState(link);
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
