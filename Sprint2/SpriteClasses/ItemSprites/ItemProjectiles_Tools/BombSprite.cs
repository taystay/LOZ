using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class BombSprite : ISprite
	{
		//-----Private Variables-----
		private Rectangle Frame;
		private Texture2D Texture;
		private double Scale;


		//-----Constructor-----
		public BombSprite(Texture2D texture, double scale)
		{
			Scale = scale;
			Texture = texture;
			Frame = new Rectangle(111, 99, 129 - 110, 133 - 98);
		}

		public void SetSize(double size)
		{
			Scale = size;
		}

		//-----Update frame-----
		public void Update(GameTime gameTime)
		{
			Scale += 0.007;
		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			int width = (int)(Scale * (int)Frame.Width);
			int height = (int)(Scale * (int)Frame.Height);
			destinationRectangle = new Rectangle(location.X, location.Y, width, height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(Texture, destinationRectangle, Frame, Color.White);
			spriteBatch.End();
		}
	}
}
