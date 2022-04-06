using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class ArrowItem : ItemAbstract
    {
        public ArrowItem(Point itemLocation)
        { 
            sprite = ItemFactory.Instance.CreateArrowUpSprite();
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
