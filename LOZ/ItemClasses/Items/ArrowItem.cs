using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    class ArrowItem : ItemAbstract
    {
        public ArrowItem(Point itemLocation)
        { 
            sprite = ItemFactory.Instance.CreateArrowUpSprite();
            _itemLocation = itemLocation;
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}
