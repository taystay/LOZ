using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class FairySprite : AbstractItemBlockClass
	{   //-----Private Variables-----
		private List<Rectangle> frames;
		private int currentFrame = 0;
		private int totalFrames = 2;

		private const int framesPerUpdate = 500;
		private int frameCounter = 0;

		//-----Constructor-----
		public FairySprite(Texture2D texture)
		{
			//scale = 2.0;
			_texture = texture;
			frames = new List<Rectangle>();
			frames.Add(new Rectangle(17, 57, 30 - 16, 85 - 56));
			frames.Add(new Rectangle(63, 57, 79 - 62, 85 - 56));
			frame = frames[currentFrame];
		}

		//-----Update frame-----
		public override void Update(GameTime timer)
		{
			frameCounter++;
			if (frameCounter > framesPerUpdate)
			{
				frameCounter = 0;
				currentFrame++;
				if (currentFrame == totalFrames)
				{
					currentFrame = 0;
				}
				frame = frames[currentFrame];
			}
		}
	}
}
