using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class Bomb : IItem
    {
        private ISprite Sprite;
        private Point ItemLocation;
        private Boolean SpriteActivity = true;
        private int FramesPassed = 0;
        private Boolean spriteChanged = false;
        private const int bombActiveTime = 100;
        private const int deadFrames = 25;
        private double scale;

        public Bomb(Point itemLocation, double size)
        {
            scale = size;
            Sprite = ItemFactory.Instance.CreateBombSprite(size);
            ItemLocation = itemLocation;
        }

        public void SetSize(double size)
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
            if (FramesPassed >= bombActiveTime)
                SpriteActivity = false;
            return SpriteActivity;
        }

        public void Update(GameTime gameTime)
        {

            Sprite.Update(gameTime);
            FramesPassed++;
            if (spriteChanged) return;
            if (FramesPassed >= bombActiveTime - deadFrames) {
                spriteChanged = true;
                Sprite = ItemFactory.Instance.CreateDeadArrowSprite(scale);
            }          
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, ItemLocation);
        }

    }
}
