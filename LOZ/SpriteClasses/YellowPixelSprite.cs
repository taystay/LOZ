using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.SpriteClasses
{
    class YellowPixelSprite : ISprite
    {
		private protected Rectangle frame;
		private protected Texture2D _texture;
		private protected Rectangle _box;

		public YellowPixelSprite(Texture2D texture, Rectangle box)
        {
			_box = box;
			_texture = texture;
			frame = new Rectangle(164, 19, 2, 2);
        }

		public void Update(GameTime timer) { }

		public void Draw(SpriteBatch spriteBatch, Point location) {
			Rectangle destinationRectangle;

			
			spriteBatch.Begin();

			destinationRectangle = new Rectangle(_box.X, _box.Y, _box.Width, 2);
			spriteBatch.Draw(_texture, destinationRectangle, frame, Color.White);
			destinationRectangle = new Rectangle(_box.X, _box.Y, 2, _box.Height);
			spriteBatch.Draw(_texture, destinationRectangle, frame, Color.White);
			destinationRectangle = new Rectangle(_box.X + _box.Width - 2, _box.Y, 2, _box.Height);
			spriteBatch.Draw(_texture, destinationRectangle, frame, Color.White);
			destinationRectangle = new Rectangle(_box.X, _box.Y + _box.Height - 2, _box.Width, 2);
			spriteBatch.Draw(_texture, destinationRectangle, frame, Color.White);

			spriteBatch.End();

		}

    }
}
