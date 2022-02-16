using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class BombSprite : ISprite
	{
		//-----Private Variables-----
		private Rectangle frame;
		private Texture2D _texture;
		private double scale = 2.0;


		//-----Constructor-----
		public BombSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(111, 99, 129 - 110, 133 - 98);
		}

		//-----Update frame-----
		public void Update(GameTime gameTime)
		{
			scale += .007;
		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			int width = (int)(scale * (int)frame.Width);
			int height = (int)(scale * (int)frame.Height);
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, Color.White);
			spriteBatch.End();
		}
	}
}
