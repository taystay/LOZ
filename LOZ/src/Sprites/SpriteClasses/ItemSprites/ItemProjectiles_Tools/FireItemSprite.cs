using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.ItemSprites
{
	class FireItemSprite : AbstractItemBlockClass
	{
		//-----Private Variables-----

		private List<Rectangle> frames;
		private int currentFrame = 0;
		private int totalFrames = 2;


		//-----Constructor-----
		public FireItemSprite(Texture2D texture)
		{
			scale = 2.0;
			_texture = texture;
			frames = new List<Rectangle>();
			frames.Add(new Rectangle(56, 103, 31, 31));
			frames.Add(new Rectangle(8, 103, 31, 31));
			frame = frames[currentFrame];
		}

		//-----Update frame-----
		public override void Update(GameTime gameTime)
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

	}
}
