using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Compass : ItemAbstract
    {
        public Compass(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateCompassSprite();
            _itemLocation = itemLocation;
        }
        public override  void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            UpdatePosition();
        }

    }
}
