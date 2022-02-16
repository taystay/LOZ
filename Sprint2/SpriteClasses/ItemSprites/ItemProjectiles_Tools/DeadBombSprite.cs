using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Sprint2
{
	class DeadBombSprite : ISprite
	{
		//-----Private Variables-----
		private List<Rectangle> frames;
		private Rectangle frame;
		private Texture2D _texture;
		private const double scale = 3.5;
		private const int totalTime = 20;
		private int timeLeft = totalTime;


		//-----Constructor-----
		public DeadBombSprite(Texture2D texture)
		{
			_texture = texture;
			frames = new List<Rectangle>();
			frames.Add(new Rectangle(189, 250, 206 - 188, 267 - 249));
			frames.Add(new Rectangle(210, 250, 227 - 209, 267 - 249));
			frames.Add(new Rectangle(231, 250, 248 - 230, 267 - 249));
		}

		//-----Update frame-----
		public void Update(GameTime gameTime)
		{
			timeLeft--;
			if (timeLeft <= totalTime / 3)
				frame = frames[2];
			else if (totalTime / 3 <= timeLeft && timeLeft <= totalTime / 3 * 2)
				frame = frames[1];
			else
				frame = frames[0];
		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;

			int width = (int)(scale * (int)frame.Width);
			int height = (int)(scale * (int)frame.Height);
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, Color.White);
			spriteBatch.End();
		}
	}
}
