using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.EnemeySprite
{
    class SpikeTrapSprite :AbstractEnemySprite
    {
        public SpikeTrapSprite(Texture2D spike) {
            _texture = spike;
            width = _texture.Width;
            height = _texture.Height;
            row = 0;
            column = 0;
            scale = 2;
        }
        public override void Update(GameTime gameTime) { }
    }
}
