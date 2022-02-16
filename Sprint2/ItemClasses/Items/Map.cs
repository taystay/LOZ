using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    public class Map : IItem
    {
        private ISprite sprite;
        private Point _itemLocation;
        private Boolean spriteActivity = true;

        public Map(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateMapSprite();
            _itemLocation = itemLocation;
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
            sprite.Draw(spriteBatch, _itemLocation);
        }

    }
}
