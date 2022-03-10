using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.EnemeySprite 
{ 
    class SkeletonSprite : AbstractEnemySprite
    {
        private const int maxFrame = 2;

        public SkeletonSprite(Texture2D sprite)
        {
            _texture = sprite;
            scale = 0.75;
            width = _texture.Width / 2;
            height = _texture.Height / 5;
        }

        public override void Update(GameTime timer)
        {
            if (timer.TotalGameTime.Milliseconds % 200 == 0)
                frame++;
            if (frame == maxFrame)
                frame = 0;
            row = 3;
            column = frame % 2;
        }
    }
}
