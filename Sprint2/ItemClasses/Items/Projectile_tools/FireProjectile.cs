using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.ItemsClasses
{
    public class FireProjectile : IItem
    {
        private ISprite sprite;
        private Point _itemLocation;
        private Boolean spriteActivity = true;
        private int deadFrames = 50;
        private int frame = 0;

        private const int dMag = 4;
        private const int slowDownSpeed = 27;
        private int dx = dMag;
        private int dy = dMag;
        private Direction _direction;

        /* make it take */
        public FireProjectile(Point itemLocation, Direction direction)
        {
            _direction = direction;
            sprite = ItemFactory.Instance.CreateFireItemSprite();
            _itemLocation = itemLocation;
        }

        public Boolean SpriteActive()
        {
            if (deadFrames <= 0)
                spriteActivity = false;
            return spriteActivity;
        }

        public void Update(GameTime gameTime)
        {
            //---Update Position---
            sprite.Update(gameTime);

            if (dx == 0 || dy == 0)
            {
                deadFrames--;
                return;
            }

            if (_direction == Direction.Up)
                _itemLocation.Y += -dy;
            else if (_direction == Direction.Right)
                _itemLocation.X += dx;
            else if (_direction == Direction.Left)
                _itemLocation.X += -dx;
            else if (_direction == Direction.Down)
                _itemLocation.Y += dy;

            if (frame % slowDownSpeed == 0) { 
                dx--;
                dy--;
            }
            frame++;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, _itemLocation);
        }

    }
}
