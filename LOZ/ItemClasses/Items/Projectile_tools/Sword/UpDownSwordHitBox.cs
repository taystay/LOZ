﻿using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class UpDownSwordHitBox : IPlayerProjectile
    {
        private int FramesPassed = 0;

        private const int TotalActiveFrames = 10;

        public UpDownSwordHitBox(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateInvisibleSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 11;
            hitBoxHeight = 28;
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