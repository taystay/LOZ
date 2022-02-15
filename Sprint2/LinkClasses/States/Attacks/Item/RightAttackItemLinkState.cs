using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;
using Sprint2.ItemsClasses.Projectile_tools;

namespace Sprint2.LinkClasses.States
{
    class RightAttackItemLinkState : ILinkState
    {
        private Point position;
        private ISprite linkSprite;
        private Link link;

        public RightAttackItemLinkState(Point location, Link link)
        {
            this.link = link;
            position = location;
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
            link.linkState = new RightIdleLinkState(position, link);
        }

        public void Move()
        {
            //Don't do anything besides attacking
        }

        public void Idle()
        {
            link.linkState = new RightIdleLinkState(position, link);
        }

        public void Attack(Weapon toUse)
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


        public void Draw(SpriteBatch spriteBatch)
        {

            linkSprite.Draw(spriteBatch, position);

        }

    }
}
