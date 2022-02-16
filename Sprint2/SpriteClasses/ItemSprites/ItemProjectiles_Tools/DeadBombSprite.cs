using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Sprint2
{
	class DeadBombSprite : ISprite
	{
		//-----Private Variables-----
		private List<Rectangle> frames;
		private Rectangle Frame;
		private Texture2D Texture;
		private double scale = 3.5;
		private const int totalTime = 20;
		private int time = totalTime;


		//-----Constructor-----
		public DeadBombSprite(Texture2D texture, double scale)
		{
			Texture = texture;
			frames = new List<Rectangle>();
			frames.Add(new Rectangle(189, 250, 206 - 188, 267 - 249));
			frames.Add(new Rectangle(210, 250, 227 - 209, 267 - 249));
			frames.Add(new Rectangle(231, 250, 248 - 230, 267 - 249));
		}

		public void SetSize(double size)
		{
		}

		//-----Update frame-----
		public void Update(GameTime gameTime)
		{
			time--;
			if (time <= totalTime/3)
				Frame = frames[2];
			else if (totalTime/3+1 <= time && time <= totalTime/3 * 2)
				Frame = frames[1];
			else
				Frame = frames[0];
		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;

			int width = (int)(scale * (int)Frame.Width);
			int height = (int)(scale * (int)Frame.Height);
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(Texture, destinationRectangle, Frame, Color.White);
			spriteBatch.End();
		}
	}
}
