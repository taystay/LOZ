using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.EnemeySprite 
{ 
    class DragonSprite : AbstractEnemySprite
    {
        private const int maxFrame = 4;
        private const int framesPerUpdate = 500;
        private int frameCounter = 0;
        public DragonSprite(Texture2D texture)
        {

            _texture = texture;
            width = _texture.Width / 2;
            height = _texture.Height / 5;
            scale = 1;
            row = frame / 2;
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
            row = frame / 2;
            column = frame % 2;

        }
    }
}
