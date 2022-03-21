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
            hitBoxWidth = 14;
            hitBoxHeight = 34;
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
