using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses.Projectile_tools
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
        private const double scale = 2.0;

        public Bomb(Point itemLocation)
        {
            Sprite = ItemFactory.Instance.CreateBombSprite(scale);
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
                Sprite = ItemFactory.Instance.CreateDeadBombSprite(scale);
            }          
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, ItemLocation);
        }

    }
}
