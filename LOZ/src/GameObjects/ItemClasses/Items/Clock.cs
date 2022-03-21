using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Clock : ItemAbstract
    { 

        public Clock(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateClockSprite();
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
