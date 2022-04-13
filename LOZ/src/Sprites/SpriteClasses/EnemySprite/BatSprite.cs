using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.EnemeySprite
{
    class BatSprite : AbstractEnemySprite
    {
        private const int maxFrame = 2;
        private const int framesPerUpdate = UpdateSpeed.BatSprite;
        private int frameCounter = 0;
        public BatSprite(Texture2D texture)
        {
            _texture = texture;
            width = (_texture.Width / 2);
            height = (_texture.Height / 5);
                scale = 0.5;
            row = 4;
            column = frame % 2;
        }

        public override void Update(GameTime timer)
        {
            frameCounter++;
            if (frameCounter > framesPerUpdate)
            {
                frame++;
                frameCounter = 0;
            }
                
            if (frame == maxFrame)
                frame = 0;
            row = 4;
            column = frame % 2;
             
        }

    }
}
