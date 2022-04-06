using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Map : ItemAbstract
    {

        public Map(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateMapSprite();
            _itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            UpdatePosition();
        }

    }
}
