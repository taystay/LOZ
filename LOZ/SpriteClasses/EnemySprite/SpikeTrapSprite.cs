using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.EnemeySprite
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
            Rectangle destinationRectangle = new Rectangle(location.X - sourceRectangle.Width / 2, location.Y - sourceRectangle.Height / 2, width * scale, height * scale);

            //for SpriteBatch.Begin(...)
            //the paramater idea was from:
            //https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
            //https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.htmls
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();

        }
    }
}
