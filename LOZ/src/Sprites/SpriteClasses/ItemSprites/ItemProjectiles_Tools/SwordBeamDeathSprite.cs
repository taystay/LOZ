using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.SpriteClasses;

namespace LOZ
{
	class SwordBeamDeathSprite : ISprite
	{
		private Rectangle topLeftProjectile;
		private Rectangle topRightProjectile;
		private Rectangle bottomLeftProjectile;
		private Rectangle bottomRightProjectile;
		private Texture2D _texture;
		private const double scale = 2.0;
		private int numUpdates = 0;
		private const int dz = 3;
		public SwordBeamDeathSprite(Texture2D texture)
		{
			_texture = texture;
			topLeftProjectile = new Rectangle(150, 246, 159 - 149, 257 - 245);
			topRightProjectile = new Rectangle(159, 246, 168 - 158, 257 - 245);
			bottomLeftProjectile = new Rectangle(150, 257, 159 - 149, 268 - 256);
			bottomRightProjectile = new Rectangle(159, 257, 168 - 158, 268 - 256);
		}

		public void ChangeScale(double scale) { }

		//-----Update frame-----
		public void Update(GameTime gameTime) => numUpdates++;

		public void DrawTopLeft(SpriteBatch spriteBatch, Point location, Color c)
        {
			int width = (int)(scale * (int)topLeftProjectile.Width);
			int height = (int)(scale * (int)topLeftProjectile.Height);
			Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Draw(_texture, destinationRectangle, topLeftProjectile, c);
		}

		public void DrawTopRight(SpriteBatch spriteBatch, Point location, Color c)
		{			
			int width = (int)(scale * (int)topRightProjectile.Width);
			int height = (int)(scale * (int)topRightProjectile.Height);
			Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Draw(_texture, destinationRectangle, topRightProjectile, c);
		}

		public void DrawBottomLeft(SpriteBatch spriteBatch, Point location, Color c)
		{
			int width = (int)(scale * (int)bottomLeftProjectile.Width);
			int height = (int)(scale * (int)bottomLeftProjectile.Height);
			Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Draw(_texture, destinationRectangle, bottomLeftProjectile, c);
		}

		public void DrawBottomRight(SpriteBatch spriteBatch, Point location, Color c)
		{	
			int width = (int)(scale * (int)bottomRightProjectile.Width);
			int height = (int)(scale * (int)bottomRightProjectile.Height);
			Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Draw(_texture, destinationRectangle, bottomRightProjectile, c);
		}
		public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);


		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
		{
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			int offset = dz * numUpdates;
			DrawTopLeft(spriteBatch, new Point(location.X - offset, location.Y - offset), c);
			DrawTopRight(spriteBatch, new Point(location.X + offset, location.Y - offset), c);
			DrawBottomLeft(spriteBatch, new Point(location.X - offset, location.Y + offset), c);
			DrawBottomRight(spriteBatch, new Point(location.X + offset, location.Y + offset), c);
			spriteBatch.End();
		}
	}
}
