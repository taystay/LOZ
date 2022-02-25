using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    public class ArrowUpItem : IItem
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

        public ArrowUpItem(Point itemLocation)
        {
            Sprite = ItemFactory.Instance.CreateArrowUpSprite();
            ItemLocation = itemLocation;
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
                Sprite = ItemFactory.Instance.CreateDeadArrowSprite();
                ItemLocation.X += DeadArrowSpriteOffSet;
                return;
            }
            
            ItemLocation.Y -= Velocity;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, ItemLocation);
        }

    }
}
