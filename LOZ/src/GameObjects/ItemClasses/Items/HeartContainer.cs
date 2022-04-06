using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class HeartContainer : ItemAbstract
    {

        public HeartContainer(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateHeartContainerSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 14;
            hitBoxHeight = 34;
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            UpdatePosition();
        }

    }
}
