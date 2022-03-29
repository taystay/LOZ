using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.SpriteClasses
{
    abstract class SpriteStandardizeClass : ISprite
    {
		private protected double scale = 1;
		private protected Rectangle frame = new Rectangle(0,0,0,0);
		private protected Texture2D _texture = null;
		public abstract void Update(GameTime timer);

		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location) {
			Draw(spriteBatch, location, Color.White);
		}
		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
		{
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			int width = (int)(scale * (int)frame.Width);
			int height = (int)(scale * (int)frame.Height);
			//something to get the correct pixel size for each sprite
			float scalewidthMult = (48 / width);
			float scaleHeightMult = (48 / height);
			int adjSpriteWidth = (int)(scalewidthMult * width);
			int adjSpriteHeight = (int)(scalewidthMult * height);
			//adjust hitbox?

			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, adjSpriteWidth, adjSpriteHeight);

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
