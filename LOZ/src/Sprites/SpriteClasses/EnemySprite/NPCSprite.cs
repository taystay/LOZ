using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.EnemeySprite 
{ 
    class NPCSprite : AbstractEnemySprite
    {
        private const int maxFrame = 3;
        private const int framesPerUpdate = 500;
        private int frameCounter = 0;
        public NPCSprite(Texture2D textue)
        {
            _texture = textue;
            scale = 3;
            frame = 1;
            width = (_texture.Width / 2);
            height = _texture.Height;
            row = 0;
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
            
            row = 0;
            column = frame % 2;
        }
    }
}
