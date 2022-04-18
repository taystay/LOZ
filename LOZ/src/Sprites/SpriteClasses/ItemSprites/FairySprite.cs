using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class FairySprite : ItemSpriteAbstract
	{  
		private readonly List<Rectangle> frames;
		private int currentFrame = 0;
		private const int framesPerUpdate = 7;
		private int frameCounter = 0;

		public FairySprite(Texture2D texture)
		{
			_texture = texture;
			frames = new List<Rectangle>();
			frames.Add(new Rectangle(17, 57, 30 - 16, 85 - 56));
			frames.Add(new Rectangle(63, 57, 79 - 62, 85 - 56));
			frame = frames[currentFrame];
		}
		public override void Update(GameTime timer)
		{
			frameCounter++;
			if (frameCounter > framesPerUpdate)
			{
				frameCounter = 0;
				currentFrame++;
				if (currentFrame == frames.Count)
					currentFrame = 0;
				frame = frames[currentFrame];
			}
		}
	}
}
