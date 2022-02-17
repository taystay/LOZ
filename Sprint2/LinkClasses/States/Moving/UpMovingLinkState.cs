
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.GameState;
using Sprint2.Factories;

namespace Sprint2.LinkClasses.States
{
    class UpMovingLinkState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;
        private const int speed = 4;

        public UpMovingLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkMovingUp();

        }

        public void Up()
        {
            //Does nothing because already facing Up            
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
            //Nothing, already moving up
        }

        public void Idle()
        {
            link.LinkState = new UpIdleLinkState(link);
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
            link.Position = new Point(link.Position.X, link.Position.Y - speed);
            linkSprite.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch, Point position)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
