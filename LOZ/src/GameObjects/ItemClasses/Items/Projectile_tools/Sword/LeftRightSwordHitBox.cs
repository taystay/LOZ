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
            hitBoxWidth = 40;
            hitBoxHeight = 50;
            Damage = 1;
        }
        public override void Update(GameTime gameTime)
        {
            UpdatePosition();
            if (spriteActivity && FramesPassed >= TotalActiveFrames)
                spriteActivity = false;

            //---Update Position---
            sprite.Update(gameTime);
            FramesPassed++;
            UpdatePosition();
        }
    }
}
