using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.ItemsClasses
{
    class FireProjectile : IPlayerProjectile
    {
        private int deadFrames = 50;
        private int frame = 0;
        private const int dMag = 4;
        private const int slowDownSpeed = 27;
        private int dx = dMag;
        private int dy = dMag;
        private Direction _direction;
        public FireProjectile(Point itemLocation, Direction direction)
        {
            _direction = direction;
            sprite = ItemFactory.Instance.CreateFireItemSprite();
            _itemLocation = itemLocation;
            hitBoxWidth = 50;
            hitBoxHeight = 50;
            Damage = 1;  
        }
        public override void Update(GameTime gameTime)
        {
            if (spriteActivity && deadFrames <= 0)
                spriteActivity = false;

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
    }
}
