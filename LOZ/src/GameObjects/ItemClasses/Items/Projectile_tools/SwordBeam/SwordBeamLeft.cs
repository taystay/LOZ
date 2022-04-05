using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class SwordBeamLeft : IPlayerProjectile
    {
        private Boolean spriteChanged = false;
        private int FramesPassed = 0;
        private const int velocity = 9;
        private const int arrowTravelTime = 100000;
        private const int deadFrames = 25;
        private const int deadArrowOffSet = -8;
        public SwordBeamLeft(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateSwordBeamLeftSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 40;
            hitBoxHeight = 14;
            Damage = 2;
        }
        public override void Update(GameTime gameTime)
        {
            if (spriteActivity && FramesPassed >= arrowTravelTime)
                spriteActivity = false;

            //---Update Position---
            sprite.Update(gameTime);
            FramesPassed++;
            if (spriteChanged) return;
            if (FramesPassed >= arrowTravelTime - deadFrames)
            {
                spriteChanged = true;
                sprite = ItemFactory.Instance.CreateDeadBeamSprite();
                _itemLocation = new Point(_itemLocation.X + deadArrowOffSet, _itemLocation.Y);
                return;
            }
            _itemLocation = new Point(_itemLocation.X - velocity, _itemLocation.Y);
        }
    }
}
