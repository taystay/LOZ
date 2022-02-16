using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class ArrowDownSprite : ISprite
	{
		//-----Private Variables-----
		private Rectangle frame;
		private Texture2D _texture;
		private const double scale = 2.0;


		//-----Constructor-----
		public ArrowDownSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(161, 55, 174 - 160, 88 - 54);
		}

		//-----Update frame-----
		public void Update(GameTime gameTime)
		{

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
