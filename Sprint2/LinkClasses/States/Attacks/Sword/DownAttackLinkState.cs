using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;

namespace Sprint2.LinkClasses.States
{
    class DownAttackLinkState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;

        public DownAttackLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkDownAttack();
        }

        public void Up()
        {
            //Don't do anything besides attacking
        }

        public void Down()
        {
            //return to idle after attack
            link.LinkState = new DownIdleLinkState(link);
        }

        public void Left()
        {
            //Don't do anything besides attacking
        }

        public void Right()
        {
            //Don't do anything besides attacking
        }

        public void Move()
        {
            //Don't do anything besides attacking
        }

        public void Idle()
        {
            link.LinkState = new DownIdleLinkState(link);
        }

        public void Attack(Weapon toUse, Point position)
        {
            //Don't do anything besides attacking
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

