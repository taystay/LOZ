using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.EnemeySprite
{
    class DragonsFireSprite : AbstractEnemySprite
    {
        private const int maxFrame = 4;
        private const int framesPerUpdate = UpdateSpeed.DragonShotSprite;
        private int frameCounter = 0;
        public DragonsFireSprite(Texture2D texture)
        {
            _texture = texture;
            width = (_texture.Width / 2);
            height = (_texture.Height / 2);
            scale = 2;
            row = frame / 2;
            column = frame % 2;
        }

        public override void Update(GameTime timer)
        {
            frameCounter++;
            if (frameCounter > framesPerUpdate)
            {
                frame++;
            }
                
            if (frame == maxFrame)
                frame = 0;
            row = frame / 2;
            column = frame % 2;
        }
    }

       


    }

