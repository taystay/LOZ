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

		public void Draw(SpriteBatch spriteBatch, Point location) {
			Draw(spriteBatch, location, Color.White);
		}

		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
		{
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			int width = (int)(scale * (int)frame.Width);
			int height = (int)(scale * (int)frame.Height);
			destinationRectangle = new Rectangle(location.X - Info.BlockWidth / 2, location.Y - Info.BlockWidth / 2, Info.BlockWidth, Info.BlockWidth);

			//for SpriteBatch.Begin(...)
			//the paramater idea was from:
			//https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
			//https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();

		}

	}
}
