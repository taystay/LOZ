using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class HeartContainerSprite : ISprite
	{
		//-----Private Variables-----
		private Rectangle frame;
		private Texture2D _texture;
		private const double scale = 2.0;


		//-----Constructor-----
		public HeartContainerSprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(102, 6, 139 - 101, 38 - 5);
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
