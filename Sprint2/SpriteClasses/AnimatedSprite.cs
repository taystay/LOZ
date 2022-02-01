using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class AnimatedSprite : ISprite
    {
		//-----Private Variables-----
		private int CurrentFrame;
		private int TotalFrames;
		private int FrameIncrease;
		private int Scale;

		private List<Rectangle> Frames;
		private Rectangle Frame;
		private Texture2D Texture;


		//-----Constructor-----
		public AnimatedSprite(Texture2D texture)
		{
			Texture = texture;


			Scale = 5;
			FrameIncrease = 9;
			TotalFrames = 3 * FrameIncrease;
			CurrentFrame = 0;

			Frames = new List<Rectangle>();
			Frames.Add(new Rectangle(91, 22, 26, 25));
			Frames.Add(new Rectangle(116, 20, 22, 25));
			Frames.Add(new Rectangle(141, 22, 27, 24));
		}

		//-----Update frame-----
		public void Update()
		{
			CurrentFrame++;
			if (CurrentFrame == TotalFrames)
			{
				CurrentFrame = 0;
			}
			Frame = Frames[CurrentFrame / FrameIncrease];
		}

		//-----Draw the given sprite-----
		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Scale * Frame.Width, Scale * Frame.Height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(Texture, destinationRectangle, Frame, Color.White);
			spriteBatch.End();
		}
	}
}
