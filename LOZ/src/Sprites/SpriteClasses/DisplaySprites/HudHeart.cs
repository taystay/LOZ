using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class HudHeart : ISprite
	{
		private Texture2D _texture;
		private Rectangle frame;
		public HudHeart(Texture2D texture, bool fullHeart)
		{
			_texture = texture;
			if (fullHeart)
				frame = new Rectangle(1, 0, 7, 6);
			else
				frame = new Rectangle(9, 0, 4, 6);
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
			int width = frame.Width * 5;
			int height = frame.Height * 5;
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

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
