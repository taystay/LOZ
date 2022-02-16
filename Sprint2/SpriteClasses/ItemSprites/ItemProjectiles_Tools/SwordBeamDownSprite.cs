using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class SwordBeamDownSprite : ISprite
	{
		private Rectangle frame;
		private Texture2D _texture;
		private const double scale = 2.0;

		public SwordBeamDownSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(18, 152, 29 - 17, 181 - 151);
		}

		public void Update(GameTime gameTime)
		{

		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;

			int width = (int)(scale * (int)frame.Width);
			int height = (int)(scale * (int)frame.Height);
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, Color.White);
			spriteBatch.End();
		}
	}
}
