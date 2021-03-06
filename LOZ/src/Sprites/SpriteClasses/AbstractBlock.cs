using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses
{
    abstract class AbstractBlock : ISprite
    {
		private protected double scale;
		private protected Rectangle frame;
		private protected Texture2D _texture;
		public abstract void Update(GameTime timer);
		public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);
		public void ChangeScale(double scale) { }

		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
		{
			Rectangle destinationRectangle = new Rectangle(location.X - Info.BlockWidth / 2, location.Y - Info.BlockWidth / 2, Info.BlockWidth, Info.BlockWidth);
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();

		}

	}
}
