using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class BlueMapRoom : ISprite
	{
		private Texture2D _texture;
		private Rectangle frame;

		public BlueMapRoom(Texture2D texture)
		{
			_texture = texture;

			frame = new Rectangle(29, 73, 1, 1);
		}

		public void Update(GameTime gameTime)
        {

        }
		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Draw(spriteBatch, location, Color.Blue);
		}

		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			int width = frame.Width * 20;
			int height = frame.Height * 10;
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
