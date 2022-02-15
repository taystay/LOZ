using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    public class Key : IItem
    {
        private ISprite sprite;
        private Point itemLocation;
        private Boolean spriteAcitvity = true;
        private const double scale = 2.0;

        public Key(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateKeySprite(scale);
            this.itemLocation = itemLocation;
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
