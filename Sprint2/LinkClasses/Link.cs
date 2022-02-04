using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Link : ILink
    {
        private Point position;
        private ISprite link;

        public Link(Point location)
        {

            position = location;
            link = LinkSpriteFactory.Instance.LinkIdle();

        }

        public void ChangeDirection()
        {
            //Nothing here yet ICommand stuff
        }

        public void Move(GameTime timer)
        {
            //Call Update?
        }
        public void Attack()
        {
            //Nothing here yet
        }

        public void Update(GameTime timer)
        {

            link.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            link.Draw(spriteBatch, position);

        }

    }
}
