using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class MapWalkWay : ISprite
	{
		private Texture2D _texture;
		private Rectangle frame;
		private int w;
		private int h;

		public MapWalkWay(Texture2D texture, int width, int height)
		{
			w = width;
			h = height;
			_texture = texture;

			frame = new Rectangle(29, 73, 1, 1);
		}
		public void Update(GameTime gameTime) { }
		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);
		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			Rectangle destinationRectangle;
			int width = frame.Width * w;
			int height = frame.Height * h;
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();
		}
	}
}
