using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Heart : ItemAbstract
    { 
        public Heart(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateHeartSprite();
            _itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            UpdatePosition();
        }

    }
}
