using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class SelectItemSprite : ISprite
	{
		private Texture2D _texture;
		private Rectangle frame;
		public SelectItemSprite(Texture2D texture)
		{
			_texture = texture;

			frame = new Rectangle(109, 0, 14, 14);
		}
		public void Update(GameTime gameTime) { }
		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);
		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			Rectangle destinationRectangle;
			int width = frame.Width * 4;
			int height = frame.Height * 4;
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();
		}
	}
}
