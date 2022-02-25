using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class SwordBeamDeathSprite : ISprite
	{
		//-----Private Variables-----
		private Rectangle topLeftProjectile;
		private Rectangle topRightProjectile;
		private Rectangle bottomLeftProjectile;
		private Rectangle bottomRightProjectile;
		private Texture2D _texture;
		private const double scale = 2.0;
		private int numUpdates = 0;

		private const int dz = 3;


		//-----Constructor-----
		public SwordBeamDeathSprite(Texture2D texture)
		{
			_texture = texture;
			topLeftProjectile = new Rectangle(150, 246, 159 - 149, 257 - 245);
			topRightProjectile = new Rectangle(159, 246, 168 - 158, 257 - 245);
			bottomLeftProjectile = new Rectangle(150, 257, 159 - 149, 268 - 256);
			bottomRightProjectile = new Rectangle(159, 257, 168 - 158, 268 - 256);
		}

		//-----Update frame-----
		public void Update(GameTime gameTime)
		{
			numUpdates++;
		}

		public void DrawTopLeft(SpriteBatch spriteBatch, Point location)
        {
			int width = (int)(scale * (int)topLeftProjectile.Width);
			int height = (int)(scale * (int)topLeftProjectile.Height);
			Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Draw(_texture, destinationRectangle, topLeftProjectile, Color.White);
		}

		public void DrawTopRight(SpriteBatch spriteBatch, Point location)
		{			
			int width = (int)(scale * (int)topRightProjectile.Width);
			int height = (int)(scale * (int)topRightProjectile.Height);
			Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Draw(_texture, destinationRectangle, topRightProjectile, Color.White);
		}

		public void DrawBottomLeft(SpriteBatch spriteBatch, Point location)
		{
			int width = (int)(scale * (int)bottomLeftProjectile.Width);
			int height = (int)(scale * (int)bottomLeftProjectile.Height);
			Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Draw(_texture, destinationRectangle, bottomLeftProjectile, Color.White);
		}

		public void DrawBottomRight(SpriteBatch spriteBatch, Point location)
		{	
			int width = (int)(scale * (int)bottomRightProjectile.Width);
			int height = (int)(scale * (int)bottomRightProjectile.Height);
			Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Draw(_texture, destinationRectangle, bottomRightProjectile, Color.White);
		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			//for SpriteBatch.Begin(...)
			//the paramater idea was from:
			//https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
			//https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			int offset = dz * numUpdates;
			DrawTopLeft(spriteBatch, new Point(location.X - offset, location.Y - offset));
			DrawTopRight(spriteBatch, new Point(location.X + offset, location.Y - offset));
			DrawBottomLeft(spriteBatch, new Point(location.X - offset, location.Y + offset));
			DrawBottomRight(spriteBatch, new Point(location.X + offset, location.Y + offset));
			spriteBatch.End();
		}
	}
}
