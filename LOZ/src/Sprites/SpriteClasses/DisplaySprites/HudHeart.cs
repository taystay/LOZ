using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class HudHeart : ISprite
	{
		private Texture2D _texture;
		private Rectangle frame;
		private double scale = 1.0;
		public HudHeart(Texture2D texture, bool fullHeart)
		{
			_texture = texture;
			if (fullHeart)
				frame = new Rectangle(1, 0, 7, 6);
			else
				frame = new Rectangle(9, 0, 4, 6);
		}

		public void Update(GameTime gameTime) { }
		public void ChangeScale(double scale) => this.scale = scale;		
		public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);
		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			Rectangle destinationRectangle;
			int width = (int)(frame.Width * 5.0 * scale);
			int height = (int)(frame.Height * 5.0 * scale);
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();
		}
	}
}
