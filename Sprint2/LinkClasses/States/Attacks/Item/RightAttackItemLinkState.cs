using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;
using Sprint2.ItemsClasses;

namespace Sprint2.LinkClasses.States
{
    class RightAttackItemLinkState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;

        public RightAttackItemLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkItemRightAttack();
        }

        public void Up()
        {
            //Don't do anything besides attacking
        }

        public void Down()
        {
            //Don't do anything besides attacking
        }

        public void Left()
        {
            //Don't do anything besides attacking
        }

        public void Right()
        {
            //return to idle after attack
            link.LinkState = new RightIdleLinkState(link);
        }

        public void Move()
        {
            //Don't do anything besides attacking
        }

        public void Idle()
        {
            link.LinkState = new RightIdleLinkState(link);
        }

        public void Attack(Weapon toUse, Point position)
        {
            //Don't do anything besides attacking
            if (toUse == Weapon.Swordbeam)
            {
                GameObjects.Instance.LinkItems.Add(new SwordBeamRight(position));
            }
            else if (toUse == Weapon.Arrow)
            {
                GameObjects.Instance.LinkItems.Add(new ArrowRightItem(position));
            }
            else if (toUse == Weapon.Bomb)
            {
                GameObjects.Instance.LinkItems.Add(new Bomb(position));
            }
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
