using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class FairySprite : ISprite
	{
		//-----Private Variables-----
		private Rectangle Frame;
		private Texture2D Texture;
		private double Scale;

		private List<Rectangle> Frames;
		private int currentFrame = 0;
		private int totalFrames = 2;


		//-----Constructor-----
		public FairySprite(Texture2D texture, double scale)
		{
			Scale = scale;
			Texture = texture;
			Frames = new List<Rectangle>();
			Frames.Add(new Rectangle(17, 57, 30 - 16, 85 - 56));
			Frames.Add(new Rectangle(63, 57, 79 - 62, 85 - 56));
			Frame = Frames[currentFrame];
		}

		public void SetSize(double size)
		{
			Scale = size;
		}

		//-----Update frame-----
		public void Update(GameTime gameTime)
		{
			if (gameTime.TotalGameTime.Milliseconds % 30 == 0)
			{
				currentFrame++;
				if (currentFrame == totalFrames)
				{
					currentFrame = 0;
				}
				Frame = Frames[currentFrame];
			}
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
