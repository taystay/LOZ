using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class ArrowLeftItem : IPlayerProjectile
    {
        private Boolean spriteChanged = false;
        private int FramesPassed = 0;
        private const int Velocity = 9;
        private const int ArrowTravelFrames = 100;
        private const int DeadFrames = 25;
        private const int DeadArrowSpriteOffSet = -8;
        public ArrowLeftItem(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateArrowLeftSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 40;
            hitBoxHeight = 14;
            Damage = 2;
        }
        public override void Update(GameTime gameTime)
        {
            if (spriteActivity && FramesPassed >= ArrowTravelFrames)
                spriteActivity = false;

            //---Update Position---
            sprite.Update(gameTime);
            FramesPassed++;
            if (spriteChanged) return;
            if (FramesPassed >= ArrowTravelFrames - DeadFrames)
            {
                spriteChanged = true;
                sprite = ItemFactory.Instance.CreateDeadArrowSprite();
                _itemLocation = new Point(_itemLocation.X + DeadArrowSpriteOffSet, _itemLocation.Y);
                return;
            }
            _itemLocation = new Point(_itemLocation.X - Velocity, _itemLocation.Y);
        }
    }
}
