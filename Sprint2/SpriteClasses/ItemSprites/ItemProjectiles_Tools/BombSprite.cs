using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class BombSprite : ISprite
	{
		private Rectangle frame;
		private Texture2D _texture;
		private double scale = 1.5;
		private Color color = new Color(255, 255, 255);

		public BombSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(111, 99, 129 - 110, 133 - 98);
		}

		public void Update(GameTime gameTime)
		{
			scale += .01;
			color.G -= 3;
			color.B -= 3;
		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;

			int width = (int)(scale * (int)frame.Width);
			int height = (int)(scale * (int)frame.Height);
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, color);
			spriteBatch.End();
		}
	}
}
