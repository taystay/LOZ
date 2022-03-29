using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class HUDSprite : ISprite
	{
		private Texture2D _texture;
		private Rectangle frame;
		int width = 256;
		int height = 231 - 169;
		public HUDSprite(Texture2D texture)
		{
			_texture = texture;
			frame = SpriteStandardizeClass.HUDSprite;
		}

		public void Update(GameTime gameTime)
        {

        }
		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Draw(spriteBatch, location, Color.White);
		}

		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			int width2 = Info.screenWidth;
			int height2 = (width2 / width + 1) * height;
			destinationRectangle = new Rectangle(location.X , location.Y, width2, height2);

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
