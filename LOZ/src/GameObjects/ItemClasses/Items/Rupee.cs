using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Rupee :ItemAbstract
    {
        public Rupee(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateRupeeSprite();
            _itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            UpdatePosition();
        }
    }
}
