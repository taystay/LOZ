using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.EnemeySprite 
{ 
    class SkeletonSprite : AbstractEnemySprite
    {
        private const int maxFrame = 2;
        private const int framesPerUpdate = UpdateSpeed.SkeletonSprite;
        private int frameCounter = 0;
        public SkeletonSprite(Texture2D sprite)
        {
            _texture = sprite;
            scale = 0.75;
            width = _texture.Width / 2;
            height = _texture.Height / 5;
            row = 3;
            column = frame % 2;
        }
        public override void Update(GameTime timer)
        {
            frameCounter++;
            if (frameCounter > framesPerUpdate)
            {
                frameCounter = 0;
                frame++;
            }
            if (frame == maxFrame)
                frame = 0;
            row = 3;
            column = frame % 2;
        }
    }
}
