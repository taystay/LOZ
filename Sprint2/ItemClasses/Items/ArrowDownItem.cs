using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class ArrowDownItem : IItem
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
        private readonly double scale;

        public ArrowDownItem(Point itemLocation, double size)
        {
            scale = size;
            Sprite = ItemFactory.Instance.CreateArrowDownSprite(size);
            ItemLocation = itemLocation;
        }

        public void SetSize(int size)
        {
            Sprite.SetSize(size);
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

            ItemLocation.Y += Velocity;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, ItemLocation);
        }

    }
}
