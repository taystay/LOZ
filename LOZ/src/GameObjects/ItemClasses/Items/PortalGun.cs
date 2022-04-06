using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class PortalGun : ItemAbstract
    {

        public PortalGun(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreatePortalGun();
            _itemLocation = itemLocation;
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            UpdatePosition();
        }
    }
}
