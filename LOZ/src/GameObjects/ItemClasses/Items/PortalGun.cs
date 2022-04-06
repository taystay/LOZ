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
