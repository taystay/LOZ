
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;

namespace Sprint2.LinkClasses.States
{
    class RightMovingLinkState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;
        private const int speed = 4;

        public RightMovingLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingRight();

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
            //Does nothing because already facing right
        }

        public void Move()
        {
            //Nothing, already moving right
        }

        public void Idle()
        {
            link.LinkState = new RightIdleLinkState( link);
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
            link.Position = new Point(link.Position.X + speed, link.Position.Y);

            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch, Point position)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
