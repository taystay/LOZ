using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class ArrowProjectile : IPlayerProjectile
    {
        private Boolean spriteChanged = false;
        private int FramesPassed = 0;
        private int _direction;
        private const int velocity = 9;
        private int VelocityX;
        private int VelocityY;
        private const int ArrowTravelFrames = 1000000;
        private const int DeadFrames = 25;
        private const int DeadArrowSpriteOffSet = -8;
        public ArrowProjectile(Point itemLocation, int direction)
        {
            ChangeDirection(direction);
            _itemLocation = itemLocation;
            Damage = 1;
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
                    sprite = ItemFactory.Instance.CreateArrowUpSprite();
                    break;
                case 1:
                    hitBoxWidth = 40;
                    hitBoxHeight = 14;
                    VelocityX = velocity;
                    VelocityY = 0;
                    sprite = ItemFactory.Instance.CreateArrowRightSprite();
                    break;
                case 2:
                    hitBoxWidth = 14;
                    hitBoxHeight = 40;
                    VelocityX = 0;
                    VelocityY = velocity;
                    sprite = ItemFactory.Instance.CreateArrowDownSprite();
                    break;
                default:
                    hitBoxWidth = 40;
                    hitBoxHeight = 14;
                    VelocityX = -velocity;
                    VelocityY = 0;
                    sprite = ItemFactory.Instance.CreateArrowLeftSprite();
                    break;
            }
            _direction = direction;
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
            _itemLocation = new Point(_itemLocation.X + VelocityX, _itemLocation.Y + VelocityY);
        }
    }
}
