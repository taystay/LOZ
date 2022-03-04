using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.SpriteClasses
{
    abstract class SpriteStandardizeClass : ISprite
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
			spriteBatch.Draw(_texture, destinationRectangle, frame, Color.White);
			spriteBatch.End();

		}

    }
}
