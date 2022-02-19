using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Sprint2.SpriteClasses.BlockSprites
{
	class Multicolored1Sprite : ISprite
	{
		private Rectangle frame;
		private readonly Texture2D _texture;
		private const double scale = 2.0;

		public Multicolored1Sprite(Texture2D texture)
		{
			_texture = texture;
			frame = new Rectangle(75, 29, 32, 32);
		}

		public void Update(GameTime gameTime)
		{

		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;

			int width = (int)(scale * frame.Width);
			int height = (int)(scale * frame.Height);
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, Color.White);
			spriteBatch.End();
		}
	}
}
