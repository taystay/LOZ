using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    class ArrowRightItem : IPlayerProjectile
    {
        private Boolean spriteChanged = false;
        private int framesPassed = 0;

        private const int Velocity = 9;
        private const int ArrowTravelFrames = 100;
        private const int DeadFrames = 25;
        private const int DeadArrowSpriteOffSet = -8;


        public ArrowRightItem(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateArrowRightSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 14;
            hitBoxHeight = 34;
        }

        public override void Update(GameTime gameTime)
        {
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
                _itemLocation.X += DeadArrowSpriteOffSet;
                return;
            }

            _itemLocation.X += Velocity;

        }

    }
}
