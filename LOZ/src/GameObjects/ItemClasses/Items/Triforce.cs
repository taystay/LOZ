using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Triforce : ItemAbstract
    {

        public Triforce(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateTriforceSprite();
            _itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            UpdatePosition();
        }

    }
}
