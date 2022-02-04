using System;
using System.Collections.Generic;
using System.Text;
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
		private Texture2D Texture;
		private double Scale;
		private int NumUpdates = 0;

		private const int DPos = 3;


		//-----Constructor-----
		public SwordBeamDeathSprite(Texture2D texture, double scale)
		{
			Scale = scale;
			Texture = texture;
			topLeftProjectile = new Rectangle(150, 246, 159 - 149, 257 - 245);
			topRightProjectile = new Rectangle(159, 246, 168 - 158, 257 - 245);
			bottomLeftProjectile = new Rectangle(150, 257, 159 - 149, 268 - 256);
			bottomRightProjectile = new Rectangle(159, 257, 168 - 158, 268 - 256);
		}

		public void SetSize(double size)
		{
			Scale = size;
		}

		//-----Update frame-----
		public void Update(GameTime gameTime)
		{
			NumUpdates++;
		}

		public void DrawTopLeft(SpriteBatch spriteBatch, Point location)
        {
			Rectangle destinationRectangle;
			int offset = DPos * NumUpdates;
			int width = (int)(Scale * (int)topLeftProjectile.Width);
			int height = (int)(Scale * (int)topLeftProjectile.Height);
			destinationRectangle = new Rectangle(location.X - offset, location.Y - offset, width, height);
			spriteBatch.Draw(Texture, destinationRectangle, topLeftProjectile, Color.White);
		}

		public void DrawTopRight(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;
			int offset = DPos * NumUpdates;
			int width = (int)(Scale * (int)topRightProjectile.Width);
			int height = (int)(Scale * (int)topRightProjectile.Height);
			destinationRectangle = new Rectangle(location.X + offset, location.Y - offset, width, height);
			spriteBatch.Draw(Texture, destinationRectangle, topRightProjectile, Color.White);
		}

		public void DrawBottomLeft(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;
			int offset = DPos * NumUpdates;
			int width = (int)(Scale * (int)bottomLeftProjectile.Width);
			int height = (int)(Scale * (int)bottomLeftProjectile.Height);
			destinationRectangle = new Rectangle(location.X - offset, location.Y + offset, width, height);
			spriteBatch.Draw(Texture, destinationRectangle, bottomLeftProjectile, Color.White);
		}

		public void DrawBottomRight(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;
			int offset = DPos * NumUpdates;
			int width = (int)(Scale * (int)bottomRightProjectile.Width);
			int height = (int)(Scale * (int)bottomRightProjectile.Height);
			destinationRectangle = new Rectangle(location.X + offset, location.Y + offset, width, height);
			spriteBatch.Draw(Texture, destinationRectangle, bottomRightProjectile, Color.White);
		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			DrawTopLeft(spriteBatch, location);
			DrawTopRight(spriteBatch, location);
			DrawBottomLeft(spriteBatch, location);
			DrawBottomRight(spriteBatch, location);
			spriteBatch.End();
		}
	}
}
