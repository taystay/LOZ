using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LOZ.SpriteClasses.ItemSprites
{
	class DeadBombSprite : ItemSpriteAbstract
	{
		private List<Rectangle> frames;
		private const int totalTime = 20;
		private int timeLeft = totalTime;
		public DeadBombSprite(Texture2D texture)
		{
			scale = 3.5;
			_texture = texture;
			frames = new List<Rectangle>();
			frames.Add(new Rectangle(189, 250, 206 - 188, 267 - 249));
			frames.Add(new Rectangle(210, 250, 227 - 209, 267 - 249));
			frames.Add(new Rectangle(231, 250, 248 - 230, 267 - 249));
		}
		public override void Update(GameTime gameTime)
		{
			timeLeft--;
			if (timeLeft <= totalTime / 3)
				frame = frames[2];
			else if (totalTime / 3 <= timeLeft && timeLeft <= totalTime / 3 * 2)
				frame = frames[1];
			else
				frame = frames[0];
		}
		public override void Draw(SpriteBatch spriteBatch, Point location, Color c)
		{
			Rectangle destinationRectangle;

			//--------FRAME 1---------
			int width = (int)(scale * frame.Width);
			int height = (int)(scale * frame.Height);
			destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			destinationRectangle.Y += 30;
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			destinationRectangle.Y -= 30;
			destinationRectangle.X += 30;
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			destinationRectangle.X -= 60;
			spriteBatch.Draw(_texture, destinationRectangle, frame, c);
			spriteBatch.End();

		}

	}
}
