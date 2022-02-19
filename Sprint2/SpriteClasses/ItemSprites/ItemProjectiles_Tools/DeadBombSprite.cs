using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Sprint2.SpriteClasses.ItemSprites
{
	class DeadBombSprite : AbstractItemBlockClass
	{
		//-----Private Variables-----
		private List<Rectangle> frames;
		private const int totalTime = 20;
		private int timeLeft = totalTime;


		//-----Constructor-----
		public DeadBombSprite(Texture2D texture)
		{
			scale = 3.5;
			_texture = texture;
			frames = new List<Rectangle>();
			frames.Add(new Rectangle(189, 250, 206 - 188, 267 - 249));
			frames.Add(new Rectangle(210, 250, 227 - 209, 267 - 249));
			frames.Add(new Rectangle(231, 250, 248 - 230, 267 - 249));
		}

		//-----Update frame-----
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

	}
}
