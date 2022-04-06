using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses.DisplaySprites
{
	class MapWalkWay : ISprite
	{
		private Texture2D _texture;
		private Rectangle frame;
		private int w;
		private int h;

		public MapWalkWay(Texture2D texture, int width, int height)
		{
			w = width;
			h = height;
			_texture = texture;

			frame = new Rectangle(29, 73, 1, 1);
		}

		public void Update(GameTime gameTime)
        {

        }
		public void IncreaseWidth(int dx)
        {
			w += dx;
        }
		public void ChangeScale(double scale) { }
		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Draw(spriteBatch, location, Color.White);
		}

		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			int width = frame.Width * w;
			int height = frame.Height * h;
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
