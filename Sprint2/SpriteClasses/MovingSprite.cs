using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class MovingSprite : ISprite
	{

		//-----Private Variables-----
		private int Scale;
		private Rectangle Frame;
		private Point Start;
		private Point Position;
		private Texture2D Texture;


		//-----Constructor-----
		public MovingSprite(Texture2D texture, Point position)
		{
			Texture = texture;
			Position = position;
			Start = position;
			Scale = 5;
			//176,13,203,43
			Frame = new Rectangle(176, 13, 27, 30);
		}

		public void Update()
		{
			Position.Y -= 4;
			if (Position.Y <= 0)
				Position.Y = Start.Y;
		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, Scale * Frame.Width, Scale * Frame.Height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(Texture, destinationRectangle, Frame, Color.White);
			spriteBatch.End();
			
		}
	}
}
