using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class HeartContainerSprite : ISprite
	{
		//-----Private Variables-----
		private Rectangle Frame;
		private Texture2D Texture;
		private double Scale;


		//-----Constructor-----
		public HeartContainerSprite(Texture2D texture, double scale)
		{
			Scale = scale;
			Texture = texture;
			Frame = new Rectangle(102, 6, 139 - 101, 38 - 5);
		}

		public void SetSize(int size)
		{
			Scale = size;
		}

		//-----Update frame-----
		public void Update(GameTime gameTime)
		{

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
