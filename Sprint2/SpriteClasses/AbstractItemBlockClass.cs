using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.SpriteClasses
{
    abstract class AbstractItemBlockClass : ISprite
    {
		private protected double scale;
		private protected Rectangle frame;
		private protected Texture2D _texture;
		public abstract void Update(GameTime timer);

		public void Draw(SpriteBatch spriteBatch, Point location) {
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
