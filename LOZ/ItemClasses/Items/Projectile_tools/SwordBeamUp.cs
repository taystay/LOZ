using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    class SwordBeamUp : IPlayerProjectile
    {
        private Boolean spriteChanged = false;
        private int FramesPassed = 0;

        private const int Velocity = 9;
        private const int ArrowTravelFrames = 100;
        private const int DeadFrames = 25;
        private const int DeadArrowSpriteOffSet = -8;

        public SwordBeamUp(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateSwordBeamUpSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 14;
            hitBoxHeight = 34;
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
                sprite = ItemFactory.Instance.CreateDeadBeamSprite();
                _itemLocation.X += DeadArrowSpriteOffSet;
                return;
            }

            _itemLocation.Y -= Velocity;

        }
    }
}
