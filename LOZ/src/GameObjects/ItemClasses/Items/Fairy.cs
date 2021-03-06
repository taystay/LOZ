using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Fairy : ItemAbstract
    {
        public Fairy(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateFairySprite();
            _itemLocation = itemLocation;
        }
        public  override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            UpdatePosition();
        }
    }
}
