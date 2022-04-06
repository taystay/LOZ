using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class ArrowUpItem : IPlayerProjectile
    {
        private Boolean spriteChanged = false;
        private int FramesPassed = 0;
        private const int Velocity = 9;
        private const int ArrowTravelFrames = 1000000;
        private const int DeadFrames = 25;
        private const int DeadArrowSpriteOffSet = -8;
        public ArrowUpItem(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateArrowUpSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 14;
            hitBoxHeight = 40;
            Damage = 1;
        }
        public override void Update(GameTime gameTime)
        {
            UpdatePosition();
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
            _itemLocation = new Point(_itemLocation.X, _itemLocation.Y - Velocity);
        }
    }
}
