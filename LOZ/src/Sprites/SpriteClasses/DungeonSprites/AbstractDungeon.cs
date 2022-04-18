using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.SpriteClasses
{
    abstract class AbstractDungeon : ISprite
    {
		private protected double scale;
		private protected Rectangle frame;
		private protected Texture2D _texture;
		private protected int width;
		private protected int height;
		public abstract void Update(GameTime timer);
		public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);
		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
		{
			Rectangle destinationRectangle;
			destinationRectangle = new Rectangle(location.X, location.Y, width, height);
			width = (int)(frame.Width * scale);
			height = (int)(frame.Height * scale);
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();

		}

	}
}
