﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class BombSprite : ISprite
	{
		//-----Private Variables-----
		private Rectangle Frame;
		private Texture2D Texture;
		private double scale = 2;


		//-----Constructor-----
		public BombSprite(Texture2D texture)
		{
			Texture = texture;
			Frame = new Rectangle(111, 99, 129 - 110, 133 - 98);
		}

		public void SetSize(double size)
		{
		}

		//-----Update frame-----
		public void Update(GameTime gameTime)
		{
			scale += .007;
		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			int width = (int)(scale * (int)Frame.Width);
			int height = (int)(scale * (int)Frame.Height);
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(Texture, destinationRectangle, Frame, Color.White);
			spriteBatch.End();
		}
	}
}
