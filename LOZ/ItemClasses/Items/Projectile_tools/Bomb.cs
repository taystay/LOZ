using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class Bomb : IPlayerProjectile
    {
        private bool spriteChanged = false;

        private int framesPassed = 0;

        private const int bombActiveTime = 100;
        private const int deadFrames = 25;


        public Bomb(Point itemLocation)
        {
            sprite = ItemFactory.Instance.CreateBombSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 14;
            hitBoxHeight = 34;
        }

        public override Rectangle GetHitBox()
        {
            if (spriteChanged)
                return  new Rectangle(_itemLocation.X - hitBoxWidth / 2, _itemLocation.Y - hitBoxHeight / 2, 75, 75);
            else
                return new Rectangle(-50, -50,0,0);

        }

        public override void Update(GameTime gameTime)
        {
            if (spriteActivity && framesPassed >= bombActiveTime)
                spriteActivity = false;

            sprite.Update(gameTime);
            framesPassed++;
            if (spriteChanged) return;
            if (framesPassed >= bombActiveTime - deadFrames) {
                spriteChanged = true;
                sprite = ItemFactory.Instance.CreateDeadBombSprite();
            }          
        }
    }
}
