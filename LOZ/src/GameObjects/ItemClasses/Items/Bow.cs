using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Bow : ItemAbstract
    {

        public Bow(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateBowSprite();
            _itemLocation = itemLocation;
            InventoryItem = true;
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            UpdatePosition();
        }
    }
}
