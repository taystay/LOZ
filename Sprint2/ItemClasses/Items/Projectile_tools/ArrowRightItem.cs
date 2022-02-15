using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses.Projectile_tools
{
    public class ArrowRightItem : IItem
    {
        private ISprite Sprite;
        private Point ItemLocation;
        private Boolean SpriteActivity = true;
        private Boolean spriteChanged = false;
        private int FramesPassed = 0;

        private const int Velocity = 9;
        private const int ArrowTravelFrames = 100;
        private const int DeadFrames = 25;
        private const int DeadArrowSpriteOffSet = -8;
        private const double scale = 2.0;

        public ArrowRightItem(Point itemLocation)
        {
            Sprite = ItemFactory.Instance.CreateArrowRightSprite(scale);
            ItemLocation = itemLocation;
        }

        public void SetPosition(Point Position)
        {
            ItemLocation.X = Position.X;
            ItemLocation.Y = Position.Y;
        }

        public void SetSpriteActivity(Boolean activity)
        {
            SpriteActivity = activity;
        }

        public Boolean SpriteActive()
        {
            if (FramesPassed >= ArrowTravelFrames)
                SpriteActivity = false;
            return SpriteActivity;
        }

        public void Update(GameTime gameTime)
        {
            //---Update Position---
            Sprite.Update(gameTime);
            FramesPassed++;
            if (spriteChanged) return;
            if (FramesPassed >= ArrowTravelFrames - DeadFrames)
            {
                spriteChanged = true;
                Sprite = ItemFactory.Instance.CreateDeadArrowSprite(scale);
                ItemLocation.X += DeadArrowSpriteOffSet;
                return;
            }

            ItemLocation.X += Velocity;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, ItemLocation);
        }

    }
}
