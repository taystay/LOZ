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
            hitBoxWidth = 14;
            hitBoxHeight = 34;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}
