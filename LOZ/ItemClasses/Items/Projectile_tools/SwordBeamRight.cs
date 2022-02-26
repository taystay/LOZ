using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    class SwordBeamRight : IPlayerProjectile
    {
        private Boolean spriteChanged = false;
        private int FramesPassed = 0;

        private const int velocity = 9;
        private const int arrowTravelFrames = 100;
        private const int deadFrames = 25;
        private const int deadArrowFrameOffset = -8;

        public SwordBeamRight(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateSwordBeamRightSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 14;
            hitBoxHeight = 34;
        }

        public override void Update(GameTime gameTime)
        {
            if (spriteActivity && FramesPassed >= arrowTravelFrames)
                spriteActivity = false;

            //---Update Position---
            sprite.Update(gameTime);
            FramesPassed++;
            if (spriteChanged) return;
            if (FramesPassed >= arrowTravelFrames - deadFrames)
            {
                spriteChanged = true;
                sprite = ItemFactory.Instance.CreateDeadBeamSprite();
                _itemLocation.X += deadArrowFrameOffset;
                return;
            }

            _itemLocation.X += velocity;

        }
    }
}
