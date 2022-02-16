using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
	class FireItemSprite : ISprite
	{
		//-----Private Variables-----
		private Rectangle frame;
		private Texture2D _texture;
		private const double scale = 2.0;

		private List<Rectangle> frames;
		private int currentFrame = 0;
		private int totalFrames = 2;


		//-----Constructor-----
		public FireItemSprite(Texture2D texture)
		{
			_texture = texture;
			frames = new List<Rectangle>();
			frames.Add(new Rectangle(56, 103, 31, 31));
			frames.Add(new Rectangle(8, 103, 31, 31));
			frame = frames[currentFrame];
		}

		//-----Update frame-----
		public void Update(GameTime gameTime)
		{
			if(gameTime.TotalGameTime.Milliseconds % 30 == 0)
            {
				currentFrame++;
				if(currentFrame == totalFrames)
                {
					currentFrame = 0;
                }
				frame = frames[currentFrame];
            }
		}

		public void Draw(SpriteBatch spriteBatch, Point location)
		{
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			int width = (int)(scale * (int)frame.Width);
			int height = (int)(scale * (int)frame.Height);
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(_texture, destinationRectangle, frame, Color.White);
			spriteBatch.End();
		}
	}
}
