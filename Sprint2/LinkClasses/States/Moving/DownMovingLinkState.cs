
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;


namespace Sprint2.LinkClasses.States
{
    class DownMovingLinkState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;
        private const int speed = 4;

        public DownMovingLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingDown();

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
            //Nothing, already moving down
        }

        public void Idle()
        {
            link.LinkState = new DownIdleLinkState(link);
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
            link.Position = new Point(link.Position.X, link.Position.Y + speed);
            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch, Point position)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
