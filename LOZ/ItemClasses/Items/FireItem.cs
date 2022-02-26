using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class FireItem : ItemAbstract
    { 
        public FireItem(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateFireItemSprite();
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
