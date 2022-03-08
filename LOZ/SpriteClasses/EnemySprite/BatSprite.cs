using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.EnemeySprite
{
    class BatSprite : AbstractEnemySprite
    {
        private const int maxFrame = 2;

        public BatSprite(Texture2D texture)
        {
            _texture = texture;
            width = (_texture.Width / 2);
            height = (_texture.Height / 5);
        }

        public override void Update(GameTime timer)
        {
            if (timer.TotalGameTime.Milliseconds % 150 == 0)
                frame++;
            if (frame == maxFrame)
                frame = 0;
            row = 4;
            column = frame % 2;
             
        }

    }
}
