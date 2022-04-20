using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class SwordProjectile : IPlayerProjectile
    {
        private Boolean spriteChanged = false;
        private int FramesPassed = 0;
        private int _direction;
        private int VelocityX;
        private int VelocityY;
        private const int velocity = 9;
        private const int ArrowTravelFrames = 100000;
        private const int DeadFrames = 25;
        private const int DeadArrowSpriteOffSet = -8;
        public SwordProjectile(Point itemLocation, int direction)
        {
            ChangeDirection(direction);
            _itemLocation = itemLocation;
            Damage = 2;
        }
        public override void ChangeDirection(int direction)
        {
            switch (direction)
            {
                case 0:
                    hitBoxWidth = 14;
                    hitBoxHeight = 40;
                    VelocityX = 0;
                    VelocityY = -velocity;
                    sprite = ItemFactory.Instance.CreateSwordBeamUpSprite();
                    break;
                case 1:
                    hitBoxWidth = 40;
                    hitBoxHeight = 14;
                    VelocityX = velocity;
                    VelocityY = 0;
                    sprite = ItemFactory.Instance.CreateSwordBeamRightSprite();
                    break;
                case 2:
                    hitBoxWidth = 14;
                    hitBoxHeight = 40;
                    VelocityX = 0;
                    VelocityY = velocity;
                    sprite = ItemFactory.Instance.CreateSwordBeamDownSprite();
                    break;
                default:
                    hitBoxWidth = 40;
                    hitBoxHeight = 14;
                    VelocityX = -velocity;
                    VelocityY = 0;
                    sprite = ItemFactory.Instance.CreateSwordBeamLeftSprite();
                    break;
            }
            _direction = direction;
        }
        public override void Update(GameTime gameTime)
        {
            if (spriteActivity && FramesPassed >= ArrowTravelFrames)
                spriteActivity = false;
            sprite.Update(gameTime);
            UpdatePosition();
            FramesPassed++;
            if (spriteChanged) return;
            if (FramesPassed >= ArrowTravelFrames - DeadFrames)
            {
                spriteChanged = true;
                sprite = ItemFactory.Instance.CreateDeadBeamSprite();
                _itemLocation = new Point(_itemLocation.X + DeadArrowSpriteOffSet, _itemLocation.Y);
                return;
            }
            _itemLocation = new Point(_itemLocation.X + VelocityX, _itemLocation.Y + VelocityY);
        }
    }
}
