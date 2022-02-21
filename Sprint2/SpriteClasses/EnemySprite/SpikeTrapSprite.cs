using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.EnemeySprite
{
    class SpikeTrapSprite :ISprite
    {
        private Texture2D _texture;
        private const int scale=2;
        public SpikeTrapSprite(Texture2D spike) {
            _texture = spike;
        }

        public void Update(GameTime gameTime) { 
        }

        public void Draw(SpriteBatch spriteBatch, Point location) {
            int width = _texture.Width;
            int height = _texture.Height;
            int row = 0;
            int column = 0;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width * scale, height * scale);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();

        }
    }
}
