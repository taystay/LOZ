using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.EnemeySprite
{
    class JellySprite : AbstractEnemySprite
    {
        private const int maxFrame = 3;
        private const int framesPerUpdate = UpdateSpeed.JellySprite;
        private int frameCounter = 0;
        public JellySprite(Texture2D texture)
        {
            _texture = texture;
            width = (_texture.Width / 2);
            height = (_texture.Height / 5);
            scale = 1;
            frame = 1;
            row = 2;
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
            row = 2;
            column = frame % 2;
        }


    }
}
