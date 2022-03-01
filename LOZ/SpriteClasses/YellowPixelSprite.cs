using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.SpriteClasses
{
    class YellowPixelSprite : ISprite
    {
		private protected Rectangle frame;
		private protected Texture2D _texture;

		public YellowPixelSprite(Texture2D texture)
        {
			_texture = texture;
			frame = new Rectangle(164, 19, 2, 2);
        }

		public void Update(GameTime timer) { }

		public void Draw(SpriteBatch spriteBatch, Point location) {
			Rectangle destinationRectangle;

			destinationRectangle = new Rectangle(location.X , location.Y , 2, 2);

			spriteBatch.Begin();
			spriteBatch.Draw(_texture, destinationRectangle, frame, Color.White);
			spriteBatch.End();

		}

    }
}
