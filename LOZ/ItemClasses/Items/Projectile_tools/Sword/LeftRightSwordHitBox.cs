using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class LeftRightSwordHitBox : IPlayerProjectile
    {
        private int FramesPassed = 0;

        private const int TotalActiveFrames = 10;

        public LeftRightSwordHitBox(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateInvisibleSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 28;
            hitBoxHeight = 11;
        }

        public override void Update(GameTime gameTime)
        {
            if (spriteActivity && FramesPassed >= TotalActiveFrames)
                spriteActivity = false;

            //---Update Position---
            sprite.Update(gameTime);
            FramesPassed++;
        }
    }
}
