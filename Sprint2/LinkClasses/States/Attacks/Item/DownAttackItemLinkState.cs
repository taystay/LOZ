using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.GameState;
using Sprint2.ItemsClasses;


namespace Sprint2.LinkClasses.States
{
    class DownAttackItemLinkState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;

        public DownAttackItemLinkState(Link link)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.LinkItemDownAttack();

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
            if(toUse == Weapon.Swordbeam)
            {
                GameObjects.Instance.LinkItems.Add(new SwordBeamDown(position));
            } else if (toUse == Weapon.Arrow)
            {
                GameObjects.Instance.LinkItems.Add(new ArrowDownItem(position));
            } else if (toUse == Weapon.Bomb)
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

