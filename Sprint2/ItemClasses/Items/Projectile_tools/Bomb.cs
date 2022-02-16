using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    public class Bomb : IItem
    {
        private ISprite sprite;
        private Point itemLocation;
        private Boolean spriteActivity = true;
        private Boolean spriteChanged = false;

        private int framesPassed = 0;

        private const int bombActiveTime = 100;
        private const int deadFrames = 25;

        public Bomb(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateBombSprite();
            this.itemLocation = itemLocation;
        }

        public Boolean SpriteActive()
        {
            if (framesPassed >= bombActiveTime)
                spriteActivity = false;
            return spriteActivity;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            framesPassed++;
            if (spriteChanged) return;
            if (framesPassed >= bombActiveTime - deadFrames) {
                spriteChanged = true;
                sprite = ItemFactory.Instance.CreateDeadBombSprite();
            }          
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, itemLocation);
        }

    }
}
