using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class MapRoom : ISprite
	{
		private Texture2D _texture;
		private Rectangle frame;
		public MapRoom(Texture2D texture)
		{
			_texture = texture;

			frame = new Rectangle(29, 73, 1, 1);
		}

		public void Update(GameTime gameTime) { }
		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);
		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			Rectangle destinationRectangle;
			int width = frame.Width * 40;
			int height = frame.Height * 20;
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();
		}
	}
}
