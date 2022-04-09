using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class ArrowRightItem : IPlayerProjectile
    {
        private Boolean spriteChanged = false;
        private int framesPassed = 0;
        private const int Velocity = 9;
        private const int ArrowTravelFrames = 1000000;
        private const int DeadFrames = 25;
        private const int DeadArrowSpriteOffSet = -8;
        public ArrowRightItem(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateArrowRightSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 40;
            hitBoxHeight = 14;
            Damage = 1;
        }
        public override void Update(GameTime gameTime)
        {
            UpdatePosition();
            if (framesPassed >= ArrowTravelFrames)
                base.spriteActivity = false;
            //---Update Position---
            sprite.Update(gameTime);
            framesPassed++;
            if (spriteChanged) return;
            if (framesPassed >= ArrowTravelFrames - DeadFrames)
            {
                spriteChanged = true;
                sprite = ItemFactory.Instance.CreateDeadArrowSprite();
                _itemLocation = new Point(_itemLocation.X + DeadArrowSpriteOffSet, _itemLocation.Y);
                return;
            }
            this.SetPosition(new Point(_itemLocation.X + Velocity, _itemLocation.Y));
        }
    }
}
