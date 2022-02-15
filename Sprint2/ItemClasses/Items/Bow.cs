using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    public class Bow : IItem
    {
        private ISprite sprite;
        private Point itemLocation;
        private bool spriteActivity = true;
        private const double scale = 2.0;

        public Bow(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateBowSprite(scale);
            this.itemLocation = itemLocation;
        }

        public void SetPosition(Point Position)
        {
            itemLocation.X = Position.X;
            itemLocation.Y = Position.Y;
        }

        public void SetSpriteActivity(bool activity)
        {
            spriteActivity = activity;
        }

        public Boolean SpriteActive()
        {
            return spriteActivity;
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
