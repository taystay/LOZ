using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class Key : IItem
    {
        private ISprite sprite;
        private Point itemLocation;
        private Boolean spriteAcitvity = true;

        public Key(Point itemLocation, double scale)
        {
            sprite = ItemFactory.Instance.CreateKeySprite(scale);
            this.itemLocation = itemLocation;
        }

        public void SetSize(double size)
        {
            sprite.SetSize(size);
        }

        public void SetPosition(Point Position)
        {
            itemLocation.X = Position.X;
            itemLocation.Y = Position.Y;
        }

        public void SetSpriteActivity(Boolean activity)
        {
            spriteAcitvity = activity;
        }

        public Boolean SpriteActive()
        {
            return spriteAcitvity;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, itemLocation);
        }

    }
}
